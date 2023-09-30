using ResumeFilter.API.Models;

namespace ResumeFilter.API.Dtos;

public class CandidateDto
{
	public Guid Id { get; set; }
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
	public string ResumeId { get; set; }
	public string UploadedBy { get; set; }
	public DateTime UploadedDate { get; set; }
	public Guid VendorId { get; set; }
	public Guid TechStackId { get; set; }
}
