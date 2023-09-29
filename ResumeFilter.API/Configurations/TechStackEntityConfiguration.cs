using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeFilter.API.Models;

namespace ResumeFilter.API.Configurations;

public class TechStackEntityConfiguration : IEntityTypeConfiguration<TechStack>
{
	public void Configure(EntityTypeBuilder<TechStack> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
		builder.Property(x => x.Name).HasColumnType("varchar(60)");
	}
}
