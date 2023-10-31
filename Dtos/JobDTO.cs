namespace Job_Api.Dtos;

public class JobDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public double Salary { get; set; }
    public DateTime PostDate { get; set; }
    public string EmployerId { get; set; }
    public string JobType { get; set; }
    public bool IsActive { get; set; }
}
