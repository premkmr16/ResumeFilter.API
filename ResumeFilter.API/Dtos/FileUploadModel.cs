namespace ResumeFilter.API.Dtos;

public class FileUploadModel
{
	public List<IFormFile> Resumes { get; set; }

	public Guid TechStackId { get; set; }

	public Guid VendorId { get; set; }
}
