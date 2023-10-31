using Job_Api.Contexts;
using Job_Api.Dtos;
using Job_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly JobDbContext _context;

    public ApplicationController(JobDbContext context)
    {
        _context = context;
    }

    // GET: api/Applications
    [HttpGet]
    public ActionResult<IEnumerable<ApplicationDTO>> GetApplications()
    {
        return _context.Applications
            .Select(a => new ApplicationDTO
            {
                Id = a.Id,
                JobId = a.JobId,
                CandidateId = a.CandidateId,
                DateApplied = a.DateApplied,
                Status = a.Status,
                IsActive = a.IsActive
            })
            .ToList();
    }

    // GET: api/Applications/5
    [HttpGet("{id}")]
    public ActionResult<ApplicationDTO> GetApplication(int id)
    {
        var application = _context.Applications.Find(id);

        if (application == null)
        {
            return NotFound();
        }

        var applicationDto = new ApplicationDTO
        {
            Id = application.Id,
            JobId = application.JobId,
            CandidateId = application.CandidateId,
            DateApplied = application.DateApplied,
            Status = application.Status,
            IsActive = application.IsActive
        };

        return applicationDto;
    }

    // POST: api/Applications
    [HttpPost]
    public ActionResult<Application> PostApplication(ApplicationDTO applicationDto)
    {
        var application = new Application
        {
            JobId = applicationDto.JobId,
            CandidateId = applicationDto.CandidateId,
            DateApplied = applicationDto.DateApplied,
            Status = applicationDto.Status,
            IsActive = applicationDto.IsActive
        };

        _context.Applications.Add(application);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetApplication), new { id = application.Id }, application);
    }

    // PUT: api/Applications/5
    [HttpPut("{id}")]
    public IActionResult PutApplication(int id, ApplicationDTO applicationDto)
    {
        if (id != applicationDto.Id)
        {
            return BadRequest();
        }

        var application = _context.Applications.Find(id);
        if (application == null)
        {
            return NotFound();
        }

        application.JobId = applicationDto.JobId;
        application.CandidateId = applicationDto.CandidateId;
        application.DateApplied = applicationDto.DateApplied;
        application.Status = applicationDto.Status;
        application.IsActive = applicationDto.IsActive;

        _context.Applications.Update(application);
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Applications/5
    [HttpDelete("{id}")]
    public IActionResult DeleteApplication(int id)
    {
        var application = _context.Applications.Find(id);

        if (application == null)
        {
            return NotFound();
        }

        _context.Applications.Remove(application);
        _context.SaveChanges();

        return NoContent();
    }
}
