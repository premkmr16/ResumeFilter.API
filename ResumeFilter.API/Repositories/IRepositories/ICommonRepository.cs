using ResumeFilter.API.Models;

namespace ResumeFilter.API.Repositories.IRepositories;

public interface ICommonRepository
{
	Task<List<Vendor>> GetVendors();
	Task<Vendor> GetVendorById(Guid id);
	Task<List<TechStack>> GetTechStacks();
	Task <TechStack> GetTechStackById(Guid id);
	Task<TechStack> CreateTechStacks(TechStack techStack);
	Task<Vendor> CreateVendors(Vendor vendor);

}
