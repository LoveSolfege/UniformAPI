using Microsoft.EntityFrameworkCore;
using UniformAPI.Entities;

namespace UniformAPI.DataAccess;

public class UniformContext(DbContextOptions<UniformContext> options) : DbContext(options)
{
	public DbSet<Uniform> Uniforms { get; set; }
	public DbSet<UniformStatus> Statuses { get; set; }
	public DbSet<UniformType> Types { get; set; }
	public DbSet<UniformDepartment> Departments { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Uniform>()
			.HasOne(u => u.UniformType)
			.WithMany(t => t.Uniforms)
			.HasForeignKey(u => u.UniformTypeId);
		
		modelBuilder.Entity<Uniform>()
			.HasOne(u => u.UniformStatus)
			.WithMany(t => t.Uniforms)
			.HasForeignKey(u => u.UniformStatusId);
		
		modelBuilder.Entity<Uniform>()
			.HasOne(u => u.UniformDepartment)
			.WithMany(t => t.Uniforms)
			.HasForeignKey(u => u.UniformDepartmentId);
		
		
		modelBuilder.Entity<UniformStatus>().HasData(
			new UniformStatus { Id = 1, Status = "Available" },
			new UniformStatus { Id = 2, Status = "In Use" },
			new UniformStatus { Id = 3, Status = "Maintenance" }
		);

		modelBuilder.Entity<UniformType>().HasData(
			new UniformType { Id = 1, Type = "Dress" },
			new UniformType { Id = 2, Type = "Pants" },
			new UniformType { Id = 3, Type = "Shirt" },
			new UniformType { Id = 4, Type = "Waist" }
		);
		
		modelBuilder.Entity<UniformDepartment>().HasData(
			new UniformDepartment { Id = 1, Department = "A" },
			new UniformDepartment { Id = 2, Department = "B" },
			new UniformDepartment { Id = 3, Department = "C" }
		);
	}

}