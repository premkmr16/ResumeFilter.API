using ResumeFilter.API.Dtos;
using ResumeFilter.API.Models;

namespace ResumeFilter.API.Services.IServices;

public interface ICommonService
{
	Task<List<VendorDto>> GetVendors();
	Task<List<TechStackDto>> GetTechStacks();
	Task<VendorDto> CreateVendors(VendorDto vendorDto);
	Task<TechStackDto> CreateTechStacks(TechStackDto techStackDto);

}
