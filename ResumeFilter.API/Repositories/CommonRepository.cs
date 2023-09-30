using Microsoft.EntityFrameworkCore;
using ResumeFilter.API.Context;
using ResumeFilter.API.Dtos;
using ResumeFilter.API.Models;
using ResumeFilter.API.Repositories.IRepositories;

namespace ResumeFilter.API.Repositories;

public class CommonRepository : ICommonRepository
{
	private readonly ResumeFilterDbContext _dbContext;

    public CommonRepository(ResumeFilterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

	public async Task<TechStack> GetTechStackById(Guid id)
	{
		return await _dbContext.TechStacks.FindAsync(id);
	}

	public async Task<List<TechStack>> GetTechStacks()
	{
		return await _dbContext.TechStacks.ToListAsync();
	}

	public async Task<Vendor> GetVendorById(Guid id)
	{
		return await _dbContext.Vendors.FindAsync(id);
	}

	public async Task<List<Vendor>> GetVendors()
	{
		return await _dbContext.Vendors.ToListAsync();
	}

    public async Task<Vendor> CreateVendors(Vendor vendor)
    {
		await _dbContext.AddAsync<Vendor>(vendor);
		await _dbContext.SaveChangesAsync();
		return vendor;
	}

    public async Task<TechStack> CreateTechStacks(TechStack techStack)
    {
		await _dbContext.AddAsync<TechStack>(techStack);
		await _dbContext.SaveChangesAsync();
		return techStack;
	}

	public async Task<List<Candidate>> GetCandidates()
	{
		return await _dbContext.Candidates.ToListAsync();
	}

	public async Task AddCandidates(List<Candidate> candidates)
	{
		await _dbContext.AddRangeAsync(candidates);
		await _dbContext.SaveChangesAsync();
	}
}
