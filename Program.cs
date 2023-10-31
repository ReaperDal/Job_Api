using Job_Api.Contexts;
using Job_Api.Helpers;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddControllers().AddOData(opts => 
opts.AddRouteComponents("odata", ODataConfiguration.GetEdmModel())
    .Count()
    .Filter()
    .OrderBy()
    .Expand()
    .Select()
    .SetMaxTop(40)
);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JobDbContext>(contextOptions => contextOptions
                .UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConn")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
