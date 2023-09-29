using Microsoft.AspNetCore.Mvc;
using ResumeFilter.API.Dtos;
using ResumeFilter.API.Services.IServices;

namespace ResumeFilter.API.Controllers;

[Route("api/common")]
[ApiController]
public class CommonController : ControllerBase
{
	private readonly ICommonService _commonService;

	public CommonController(ICommonService commonService)
	{
		_commonService = commonService;
	}

	[HttpGet]
	[Route("vendors")]
	public async Task<IActionResult> GetVendors()
	{
		List<VendorDto> vendors = await _commonService.GetVendors();

		if (!vendors.Any())
		{
			return Ok(new List<VendorDto>());
		}

		return Ok(vendors);
	}

	[HttpGet]
	[Route("techstacks")]
	public async Task<IActionResult> GetTechStacks()
	{
		List<TechStackDto> techStacks = await _commonService.GetTechStacks();

		if (!techStacks.Any())
		{
			return Ok(new List<TechStackDto>());
		}

		return Ok(techStacks);
	}
}
