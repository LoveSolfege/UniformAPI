using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using UniformAPI.DataAccess;
using UniformAPI.Entities;
using UniformAPI.Entities.DTO;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddProblemDetails();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<UniformContext>(opts =>
	opts.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<JsonOptions>(options =>
{
	options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();



//GET
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

app.MapGet("/departments", async (UniformContext db) =>
{
	var departments = await db.Departments.ToListAsync();
	return Results.Ok(departments);
});

app.MapGet("/uniform/all", async (UniformContext db, IMapper mapper) =>
{
	return Results.Ok(await db.Uniforms
		.ProjectTo<UniformDto>(mapper.ConfigurationProvider)
		.AsNoTracking()
		.ToListAsync());
});

app.MapGet("/uniform/{id}", async (UniformContext db, int id, IMapper mapper) =>
{
	var uniformDto = await db.Uniforms
		.AsNoTracking()
		.Where(u => u.Id == id)
		.ProjectTo<UniformDto>(mapper.ConfigurationProvider)
		.FirstOrDefaultAsync();

	return uniformDto == null ? Results.NotFound() : Results.Ok(uniformDto);

});

//POST
app.MapPost("/uniform/add", async (UniformCreateDto dto, 
	UniformContext db, 
	IMapper mapper) => 
{
	var uniform = mapper.Map<Uniform>(dto);
	db.Uniforms.Add(uniform);
	await db.SaveChangesAsync();

	// Load relationships if needed
	var createdEntity = await db.Uniforms
		.Include(u => u.UniformType)
		.Include(u => u.UniformStatus)
		.Include(u => u.UniformDepartment)
		.FirstOrDefaultAsync(u => u.Id == uniform.Id);

	return Results.Created(
		$"/uniform/{uniform.Id}", 
		mapper.Map<UniformDto>(createdEntity));
});



app.Run();