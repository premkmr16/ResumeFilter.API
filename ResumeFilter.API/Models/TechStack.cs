namespace ResumeFilter.API.Models;

public class TechStack
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public ICollection<Candidate> Candidates { get; set; }
}
