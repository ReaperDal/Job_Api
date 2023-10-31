using Job_Api.Contexts;
using Job_Api.Dtos;
using Job_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly JobDbContext _context;

    public UserController(JobDbContext context)
    {
        _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public ActionResult<IEnumerable<UserDTO>> GetUsers()
    {
        return _context.Users
            .Select(u => new UserDTO
            {
                Id = u.Id,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                FirstName = u.FirstName,
                LastName = u.LastName
            })
            .ToList();
    }

    // GET: api/Users/{id}
    [HttpGet("{id}")]
    public ActionResult<UserDTO> GetUser(Guid id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        var userDto = new UserDTO
        {
            Id = user.Id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        return userDto;
    }

    // POST: api/Users
    [HttpPost]
    public ActionResult<User> PostUser(UserDTO userDto)
    {
        var user = new User
        {
            Email = userDto.Email,
            Password = userDto.Password, 
            PhoneNumber = userDto.PhoneNumber,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // PUT: api/Users/{id}
    [HttpPut("{id}")]
    public IActionResult PutUser(Guid id, UserDTO userDto)
    {
        if (id != userDto.Id)
        {
            return BadRequest();
        }

        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        user.Email = userDto.Email;
        user.Password = userDto.Password; 
        user.PhoneNumber = userDto.PhoneNumber;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;

        _context.Users.Update(user);
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Users/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }
}
