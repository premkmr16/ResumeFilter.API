using ResumeFilter.API.Dtos;
using ResumeFilter.API.Mappers;
using ResumeFilter.API.Models;
using ResumeFilter.API.Repositories.IRepositories;
using ResumeFilter.API.Services.IServices;

namespace ResumeFilter.API.Services
{
	public class CommonService : ICommonService
	{
		private readonly ICommonRepository _commonRepository;

        public CommonService(ICommonRepository commonRepository)
        {
			_commonRepository = commonRepository;
        }

		public async Task<List<TechStackDto>> GetTechStacks()
		{
			List<TechStack> techStacks = await _commonRepository.GetTechStacks();

			return techStacks.ToTechStackDto();
		}

		public async Task<List<VendorDto>> GetVendors()
		{
			List<Vendor> vendors = await _commonRepository.GetVendors();

			return vendors.ToVendorDto();
		}
	}
}
