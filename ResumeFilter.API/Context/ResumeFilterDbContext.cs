using Microsoft.EntityFrameworkCore;
using ResumeFilter.API.Configurations;
using ResumeFilter.API.Models;

namespace ResumeFilter.API.Context;

public class ResumeFilterDbContext : DbContext
{
    public ResumeFilterDbContext(DbContextOptions<ResumeFilterDbContext> options)
        : base(options)
    {

    }

    public DbSet<Candidate> Candidates { get; set; }
	public DbSet<Vendor> Vendors { get; set; }
	public DbSet<TechStack> TechStacks { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CandidateEntityConfiguration());
		modelBuilder.ApplyConfiguration(new VendorEntityConfiguration());
		modelBuilder.ApplyConfiguration(new TechStackEntityConfiguration());

		SeedData(modelBuilder);
		SetCasCadeDelete(modelBuilder);

		base.OnModelCreating(modelBuilder);
	}

	private static void SeedData(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<TechStack>().HasData(
			new TechStack { Id = Guid.NewGuid(), Name = "React, dotnet, Azure" },
			new TechStack { Id = Guid.NewGuid(), Name = "Angular, dotnet, Azure" },
			new TechStack { Id = Guid.NewGuid(), Name = "React, java, Azure" }
		);

		modelBuilder.Entity<Vendor>().HasData(
			new TechStack { Id = Guid.NewGuid(), Name = "Hema" },
			new TechStack { Id = Guid.NewGuid(), Name = "Sudha" },
			new TechStack { Id = Guid.NewGuid(), Name = "prem" },
			new TechStack { Id = Guid.NewGuid(), Name = "Vaishnavi" },
			new TechStack { Id = Guid.NewGuid(), Name = "Abi" }
		);
	}

	private static void SetCasCadeDelete(ModelBuilder modelBuilder)
	{
		foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
			.SelectMany(table => table.GetForeignKeys()
			.Where(fk => !fk.IsOwnership && fk.DeleteBehavior is DeleteBehavior.Cascade)))
		{
			foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
		}
	}
}
