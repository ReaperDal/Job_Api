namespace Job_Api.Dtos;

public class ApplicationDTO
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public string CandidateId { get; set; }
    public DateTime DateApplied { get; set; }
    public string Status { get; set; }
    public bool IsActive { get; set; }
}
