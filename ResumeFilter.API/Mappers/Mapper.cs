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
	public static VendorDto ToVendor(this Vendor vendor)
	{
		return new VendorDto  { Id = vendor.Id, Name = vendor.Name };
	}
	public static Vendor ToCreateVendorDto(this VendorDto vendor)
	{
		return new Vendor { Id = vendor.Id, Name = vendor.Name };
	}
	public static TechStackDto ToTechStack(this TechStack techStack)
	{
		return new TechStackDto { Id = techStack.Id, Name = techStack.Name };
	}
	public static TechStack ToCreateTechStackDto(this TechStackDto techStack)
	{
		return new TechStack { Id = techStack.Id, Name = techStack.Name };
	}
}
