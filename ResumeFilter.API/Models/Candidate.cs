namespace ResumeFilter.API.Models;

public class Candidate
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
	public string ResumeId { get; set; }
	public string UploadedBy { get; set; }
	public DateTime UploadedDate { get; set; }

	public Guid VendorId { get; set; }
	public Vendor Vendor { get; set; }

	public Guid TechStackId { get; set; }
	public TechStack TechStack { get; set; }
}
