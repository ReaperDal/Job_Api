using Job_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Job_Api.Contexts;

public class JobDbContext : DbContext
{
    public JobDbContext(DbContextOptions<JobDbContext> contextOptions) : base(contextOptions)
    {

    }

    public DbSet<Application> Applications { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<User> Users { get; set; }
}
