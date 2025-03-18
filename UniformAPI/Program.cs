using Microsoft.EntityFrameworkCore;
using UniformAPI.DataAccess;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<UniformContext>(opts =>
	opts.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", async (UniformContext context) =>
{
	await context.Database.EnsureCreatedAsync();
	return "Database initialized!";
});

app.MapGet("/types", async (UniformContext db) =>
{
	var types = await db.Types.ToListAsync();
	return Results.Ok(types);
});

app.MapGet("/statuses", async (UniformContext db) =>
{
	var statuses = await db.Statuses.ToListAsync();
	return Results.Ok(statuses);
});

app.Run();