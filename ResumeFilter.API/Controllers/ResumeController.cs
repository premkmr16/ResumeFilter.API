using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeFilter.API.Dtos;
using ResumeFilter.API.Services.IServices;
using System.IO.Compression;

namespace ResumeFilter.API.Controllers
{
	[Route("api/resume")]
	[ApiController]
	public class ResumeController : ControllerBase
	{
		private readonly IBlobService _blobService;
		private readonly IPdfService _pdfService;

		public ResumeController(IBlobService blobService, IPdfService pdfService)
		{
			_blobService = blobService;
			_pdfService = pdfService;
		}

		[HttpPost]
		[Route("uploadpdfresumes")]
		public async Task<IActionResult> UploadPdfResumes([FromForm] FileUploadModel fileUploadModel)
		{
			var duplicates = await _blobService.UploadResumes(fileUploadModel.Resumes, fileUploadModel.VendorId, fileUploadModel.TechStackId);

			if (!duplicates.Any())
			{
				return Ok();
			}

			return Ok(duplicates);
		}

		[HttpPost]
		[Route("uploadzipfile")]
		public async Task<IActionResult> UploadZipFiles([FromForm] ZipModel zip)
		{
			if (zip.ZipFile == null || zip.ZipFile.Length == 0)
			{
				return BadRequest("Zip file not uploaded or Invalid zip file");
			}

			var duplicates = await _blobService.ExtractAndUploadResume(zip.ZipFile, zip.VendorId, zip.TechStackId);

			if (!duplicates.Any())
			{
				return Ok();
			}

			return Ok(duplicates);
		}
	}
}