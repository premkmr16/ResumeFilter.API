using ResumeFilter.API.Dtos;

namespace ResumeFilter.API.Services.IServices;

public interface IBlobService
{
	public Task<List<DuplicateResume>> UploadResumes(List<IFormFile> resumes, Guid vendorId, Guid techStackId);

	public Task<List<DuplicateResume>> ExtractAndUploadResume(IFormFile zipFile, Guid vendorId, Guid techStackId);
}
