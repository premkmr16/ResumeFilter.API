namespace ResumeFilter.API.Dtos
{
	public class ZipModel
	{
		public IFormFile ZipFile { get; set; }
		public Guid VendorId { get; set; }
		public Guid TechStackId { get; set; }
	}
}
