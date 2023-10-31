using Job_Api.Contexts;
using Job_Api.Dtos;
using Job_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Job_Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly JobDbContext _context;

    public JobController(JobDbContext context)
	{
        _context = context;
    }

    // GET: api/Jobs
    [HttpGet]
    public ActionResult<IEnumerable<JobDTO>> GetJobs()
    {
        return _context.Jobs
            .Select(j => new JobDTO
            {
                Id = j.Id,
                Title = j.Title,
                Description = j.Description,
                Location = j.Location,
                Salary = j.Salary,
                PostDate = j.PostDate,
                EmployerId = j.EmployerId,
                JobType = j.JobType,
                IsActive = j.IsActive
            })
            .ToList();
    }

    // GET: api/Jobs/5
    [HttpGet("{id}")]
    public ActionResult<JobDTO> GetJob(int id)
    {
        var job = _context.Jobs.Find(id);

        if (job == null)
        {
            return NotFound();
        }

        var jobDto = new JobDTO
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            Location = job.Location,
            Salary = job.Salary,
            PostDate = job.PostDate,
            EmployerId = job.EmployerId,
            JobType = job.JobType,
            IsActive = job.IsActive
        };

        return jobDto;
    }

    // POST: api/Jobs
    [HttpPost]
    public ActionResult<Job> PostJob(JobDTO jobDto)
    {
        var job = new Job
        {
            Title = jobDto.Title,
            Description = jobDto.Description,
            Location = jobDto.Location,
            Salary = jobDto.Salary,
            PostDate = jobDto.PostDate,
            EmployerId = jobDto.EmployerId,
            JobType = jobDto.JobType,
            IsActive = jobDto.IsActive
        };

        _context.Jobs.Add(job);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
    }

    // PUT: api/Jobs/5
    [HttpPut("{id}")]
    public IActionResult PutJob(int id, JobDTO jobDto)
    {
        if (id != jobDto.Id)
        {
            return BadRequest();
        }

        var job = _context.Jobs.Find(id);
        if (job == null)
        {
            return NotFound();
        }

        job.Title = jobDto.Title;
        job.Description = jobDto.Description;
        job.Location = jobDto.Location;
        job.Salary = jobDto.Salary;
        job.PostDate = jobDto.PostDate;
        job.EmployerId = jobDto.EmployerId;
        job.JobType = jobDto.JobType;
        job.IsActive = jobDto.IsActive;

        _context.Jobs.Update(job);
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Jobs/5
    [HttpDelete("{id}")]
    public IActionResult DeleteJob(int id)
    {
        var job = _context.Jobs.Find(id);

        if (job == null)
        {
            return NotFound();
        }

        _context.Jobs.Remove(job);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpGet("odata")]
    [EnableQuery]
    public IQueryable<Job> GetODataJobs()
    {
        return _context.Jobs;
    }

}
