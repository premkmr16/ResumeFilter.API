using Azure;
using Azure.Storage.Blobs;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using ResumeFilter.API.Dtos;
using ResumeFilter.API.Mappers;
using ResumeFilter.API.Models;
using ResumeFilter.API.Repositories.IRepositories;
using ResumeFilter.API.Services.IServices;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace ResumeFilter.API.Services;

public class BlobService : IBlobService
{
	private readonly BlobServiceClient _blobServiceClient;
	private readonly BlobContainerClient _blobContainerClient;
	private readonly ICommonRepository _commonRepository;

	private readonly string blobConnectionString = "";


	public BlobService(ICommonRepository commonRepository)
	{
		_blobServiceClient = new BlobServiceClient(blobConnectionString);
		_blobContainerClient = _blobServiceClient.GetBlobContainerClient("candidate-resumes");
		_commonRepository = commonRepository;
	}

	public async Task<List<DuplicateResume>> UploadResumes(List<IFormFile> resumes, Guid vendorId, Guid techStackId)
	{
		try
		{
			List<Candidate> candidates = await _commonRepository.GetCandidates();

			List<Candidate> toAddCandidates = new();

			List<DuplicateResume> duplicates = new();

			foreach (var resume in resumes)
			{
				if (resume.Length > 0)
				{
					using var pdfStream = resume.OpenReadStream();
					ContactInfo contactInfo = ExtractContactInfo(pdfStream);

					if (!candidates.Any())
					{
						string blobName = $"{Guid.NewGuid()}-{Path.GetFileName(resume.FileName)}";
						BlobClient blobClient = _blobContainerClient.GetBlobClient(blobName);

						using var stream = resume.OpenReadStream();
						await blobClient.UploadAsync(stream, true);

						toAddCandidates.Add(contactInfo.ToCandidate(blobName, vendorId, techStackId));
					}

					else
					{
						Candidate duplicateResume = candidates.Find(x => x.Email == contactInfo.Email && x.PhoneNumber == contactInfo.PhoneNumber);

						if (duplicateResume is not null)
						{
							duplicates.Add(new DuplicateResume { FileName = resume.FileName, UploadedBy = duplicateResume.UploadedBy });
							continue;
						}

						string blobName = $"{Guid.NewGuid()}-{Path.GetFileName(resume.FileName)}";
						BlobClient blobClient = _blobContainerClient.GetBlobClient(blobName);

						using var stream = resume.OpenReadStream();
						await blobClient.UploadAsync(stream, true);

						toAddCandidates.Add(contactInfo.ToCandidate(blobName, vendorId, techStackId));
					}
				}
			}

			await _commonRepository.AddCandidates(toAddCandidates);

			return duplicates;
		}

		catch (RequestFailedException exception)
		{
			throw new RequestFailedException($"Error uploading file to blob storage: {exception.Message}", exception);
		}

		catch (Exception ex)
		{
			throw new Exception($"Unexpected error: {ex.Message}", ex);
		}
	}

	public async Task<List<DuplicateResume>> ExtractAndUploadResume(IFormFile zipFile, Guid vendorId, Guid techStackId)
	{
		List<Candidate> candidates = await _commonRepository.GetCandidates();

		List<Candidate> toAddCandidates = new();

		List<DuplicateResume> duplicates = new();

		using var zipStream = new MemoryStream();

		await zipFile.CopyToAsync(zipStream);

		using var archive = new ZipArchive(zipStream, ZipArchiveMode.Read);

		foreach (var resume in archive.Entries)
		{
			if (resume.FullName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
			{
				using var pdfStream = resume.Open();

				ContactInfo contactInfo = ExtractContactInfo(pdfStream);

				var name = Path.GetFileName(resume.Name);

				if (!candidates.Any())
				{
					string blobName = $"{Guid.NewGuid()}-{Path.GetFileName(resume.Name)}";
					BlobClient blobClient = _blobContainerClient.GetBlobClient(blobName);

					await blobClient.UploadAsync(pdfStream, true);

					toAddCandidates.Add(contactInfo.ToCandidate(blobName, vendorId, techStackId));
				}

				else
				{
					Candidate duplicateResume = candidates.Find(x => x.Email == contactInfo.Email && x.PhoneNumber == contactInfo.PhoneNumber);

					if (duplicateResume is not null)
					{
						duplicates.Add(new DuplicateResume { FileName = resume.Name, UploadedBy = duplicateResume.UploadedBy });
						continue;
					}

					string blobName = $"{Guid.NewGuid()}-{Path.GetFileName(resume.Name)}";
					BlobClient blobClient = _blobContainerClient.GetBlobClient(blobName);

					await blobClient.UploadAsync(pdfStream, true);

					toAddCandidates.Add(contactInfo.ToCandidate(blobName, vendorId, techStackId));
				}
			}
		}

		await _commonRepository.AddCandidates(toAddCandidates);

		return duplicates;
	}

	static ContactInfo ExtractContactInfo(Stream pdfStream)
	{
		using PdfReader pdfReader = new(pdfStream);

		using PdfDocument pdfDocument = new(pdfReader);

		int numberOfPages = pdfDocument.GetNumberOfPages();

		ContactInfo contactInfo = new();

		for (int pageNum = 1; pageNum <= numberOfPages; pageNum++)
		{
			string text = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNum));

			string email = ExtractEmail(text);

			string phoneNumber = ExtractPhoneNumber(text);

			contactInfo = new ContactInfo { Email = email, PhoneNumber = phoneNumber };
		}

		return contactInfo;
	}

	static string ExtractEmail(string text)
	{
		string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
		MatchCollection matches = Regex.Matches(text, emailPattern);

		return matches.FirstOrDefault()?.Value;
	}

	static string ExtractPhoneNumber(string text)
	{
		string phonePattern = @"\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}";
		MatchCollection matches = Regex.Matches(text, phonePattern);

		return matches.FirstOrDefault()?.Value;
	}
}

