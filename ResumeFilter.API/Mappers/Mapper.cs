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
}
