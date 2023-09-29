﻿using ResumeFilter.API.Dtos;
using ResumeFilter.API.Models;

namespace ResumeFilter.API.Services.IServices;

public interface ICommonService
{
	Task<List<VendorDto>> GetVendors();
	Task<List<TechStackDto>> GetTechStacks();
}