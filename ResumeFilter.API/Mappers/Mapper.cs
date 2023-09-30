using ResumeFilter.API.Dtos;
using ResumeFilter.API.Models;

namespace ResumeFilter.API.Mappers;

public static class Mapper
{
	public static List<TechStackDto> ToTechStackDto(this List<TechStack> techStacks)
	{
		return techStacks.Select(techStack => new TechStackDto { Id = techStack.Id, Name = techStack.Name }).ToList();
	}

	public static List<VendorDto> ToVendorDto(this List<Vendor> vendors)
	{
		return vendors.Select(vendor => new VendorDto { Id = vendor.Id, Name = vendor.Name }).ToList();
	}

	public static VendorDto ToVendorDto(this Vendor vendor)
	{
		return new VendorDto { Id = vendor.Id, Name = vendor.Name };
	}

	public static Vendor ToVendor(this VendorDto vendor)
	{
		return new Vendor { Id = vendor.Id, Name = vendor.Name };
	}

	public static TechStackDto ToTechStackDto(this TechStack techStack)
	{
		return new TechStackDto { Id = techStack.Id, Name = techStack.Name };
	}

	public static TechStack ToTechStack(this TechStackDto techStack)
	{
		return new TechStack { Id = techStack.Id, Name = techStack.Name };
	}

	public static Candidate ToCandidate(this ContactInfo contactInfo)
	{
		return new Candidate { Email = contactInfo.Email, PhoneNumber = contactInfo.PhoneNumber, UploadedDate = DateTime.UtcNow };
	}

	public static Candidate ToCandidate(this ContactInfo contactInfo, string blobId, Guid vendorId, Guid techStackId)
	{
		return new Candidate
		{
			Email = contactInfo.Email,
			PhoneNumber = contactInfo.PhoneNumber,
			UploadedDate = DateTime.UtcNow,
			TechStackId = techStackId,
			VendorId = vendorId,
			ResumeId = blobId
		};
	}

	public static List<CandidateDto> ToCandidateDto(this List<Candidate> candidates)
	{
		return candidates.Select(candidate => new CandidateDto
		{
			Id = candidate.Id,
			Email = candidate.Email,
			PhoneNumber = candidate.PhoneNumber,
			ResumeId = candidate.ResumeId,
			TechStackId = candidate.TechStackId,
			VendorId = candidate.VendorId,
			UploadedDate = candidate.UploadedDate
		}).ToList();
	}
}
