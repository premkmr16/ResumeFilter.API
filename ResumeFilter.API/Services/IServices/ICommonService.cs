using ResumeFilter.API.Dtos;
using ResumeFilter.API.Models;

namespace ResumeFilter.API.Services.IServices;

public interface ICommonService
{
	Task<List<VendorDto>> GetVendors();
	Task<List<TechStackDto>> GetTechStacks();
	Task<VendorDto> CreateVendor(VendorDto vendorDto);
	Task<TechStackDto> CreateTechStack(TechStackDto techStackDto);
	Task<List<CandidateDto>> GetCandidates();
}
