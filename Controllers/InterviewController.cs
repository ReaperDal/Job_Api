using Job_Api.Contexts;
using Job_Api.Dtos;
using Job_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InterviewController : ControllerBase
{
    private readonly JobDbContext _context;

    public InterviewController(JobDbContext context)
    {
        _context = context;
    }

    // GET: api/Interviews
    [HttpGet]
    public ActionResult<IEnumerable<InterviewDTO>> GetInterviews()
    {
        return _context.Interviews
            .Select(i => new InterviewDTO
            {
                Id = i.Id,
                ApplicationId = i.ApplicationId,
                DateScheduled = i.DateScheduled,
                InterviewerName = i.InterviewerName,
                Result = i.Result
            })
            .ToList();
    }

    // GET: api/Interviews/5
    [HttpGet("{id}")]
    public ActionResult<InterviewDTO> GetInterview(int id)
    {
        var interview = _context.Interviews.Find(id);

        if (interview == null)
        {
            return NotFound();
        }

        var interviewDto = new InterviewDTO
        {
            Id = interview.Id,
            ApplicationId = interview.ApplicationId,
            DateScheduled = interview.DateScheduled,
            InterviewerName = interview.InterviewerName,
            Result = interview.Result
        };

        return interviewDto;
    }

    // POST: api/Interviews
    [HttpPost]
    public ActionResult<Interview> PostInterview(InterviewDTO interviewDto)
    {
        var interview = new Interview
        {
            ApplicationId = interviewDto.ApplicationId,
            DateScheduled = interviewDto.DateScheduled,
            InterviewerName = interviewDto.InterviewerName,
            Result = interviewDto.Result
        };

        _context.Interviews.Add(interview);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetInterview), new { id = interview.Id }, interview);
    }

    // PUT: api/Interviews/5
    [HttpPut("{id}")]
    public IActionResult PutInterview(int id, InterviewDTO interviewDto)
    {
        if (id != interviewDto.Id)
        {
            return BadRequest();
        }

        var interview = _context.Interviews.Find(id);
        if (interview == null)
        {
            return NotFound();
        }

        interview.ApplicationId = interviewDto.ApplicationId;
        interview.DateScheduled = interviewDto.DateScheduled;
        interview.InterviewerName = interviewDto.InterviewerName;
        interview.Result = interviewDto.Result;

        _context.Interviews.Update(interview);
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Interviews/5
    [HttpDelete("{id}")]
    public IActionResult DeleteInterview(int id)
    {
        var interview = _context.Interviews.Find(id);

        if (interview == null)
        {
            return NotFound();
        }

        _context.Interviews.Remove(interview);
        _context.SaveChanges();

        return NoContent();
    }
}
