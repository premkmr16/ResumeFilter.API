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

	[HttpPost]
	[Route("createtechstacks")]
	public async Task<IActionResult> CreateTechStacks(TechStackDto techStackDto)
	{
		TechStackDto techStacks = await _commonService.CreateTechStack(techStackDto);

		return Ok("Techstack created successfully");
	}

	[HttpPost]
	[Route("createvendors")]
	public async Task<IActionResult> CreateVendors(VendorDto vendorDto)
	{
		VendorDto vendor = await _commonService.CreateVendor(vendorDto);

		return Ok("Vendor created successfully");
	}

	[HttpPost]
	[Route("getcandidates")]
	public async Task<IActionResult> GetCandidates()
	{
		List<CandidateDto> candidates = await _commonService.GetCandidates();

		if (!candidates.Any())
		{
			return Ok(new List<CandidateDto>());
		}

		return Ok(candidates);
	}
}
