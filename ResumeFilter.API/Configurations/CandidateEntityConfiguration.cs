using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeFilter.API.Models;

namespace ResumeFilter.API.Configurations;

public class CandidateEntityConfiguration : IEntityTypeConfiguration<Candidate>
{
	public void Configure(EntityTypeBuilder<Candidate> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
		builder.Property(x => x.Name).HasColumnType("varchar(60)");
		builder.Property(x => x.Email).HasColumnType("varchar(254)");
		builder.Property(x => x.PhoneNumber).HasColumnType("varchar(15)");
		builder.HasOne(x => x.TechStack).WithMany(x => x.Candidates).HasForeignKey(x => x.TechStackId);
		builder.Property(x => x.ResumeId).HasColumnType("varchar(60)");
		builder.Property(x => x.UploadedBy).HasColumnType("varchar(50)");
		builder.Property(x => x.UploadedDate).HasColumnType("datetime2").HasDefaultValue(DateTime.UtcNow);
		builder.HasOne(x => x.Vendor).WithMany(x => x.Candidates).HasForeignKey(x => x.VendorId);
	}
}
