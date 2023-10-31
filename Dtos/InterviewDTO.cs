namespace Job_Api.Dtos;

public class InterviewDTO
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public DateTime DateScheduled { get; set; }
    public string InterviewerName { get; set; }
    public string? Result { get; set; }
}
