using Microsoft.EntityFrameworkCore;
using ResumeFilter.API.Models;

namespace ResumeFilter.API.Context;

public class ResumeFilterDbContext : DbContext
{
    public ResumeFilterDbContext(DbContextOptions<ResumeFilterDbContext> options)
        : base(options)
    {

    }

    public DbSet<Employee> Employees { get; set; }
}
