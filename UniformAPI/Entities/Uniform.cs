using System.ComponentModel.DataAnnotations;

namespace UniformAPI.Entities;

public class Uniform
{
	public int Id { get; set; }
	[Required]
	public string Barcode { get; set; }
	
	[Required]
	public int UniformTypeId { get; set; }
	[Required]
	public int UniformStatusId { get; set; }
	[Required]
	public int UniformDepartmentId { get; set; }
	
	public UniformType UniformType { get; set; }
	public UniformStatus UniformStatus { get; set; }
	public UniformDepartment UniformDepartment { get; set; }
}

