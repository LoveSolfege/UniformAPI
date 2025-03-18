namespace UniformAPI.Entities;

public class Uniform
{
	public int Id { get; set; }
	public string Barcode { get; set; }
	
	public int UniformTypeId { get; set; }
	public int UniformStatusId { get; set; }
	public int UniformDepartmentId { get; set; }
	
	public UniformType UniformType { get; set; }
	public UniformStatus UniformStatus { get; set; }
	public UniformDepartment UniformDepartment { get; set; }
}

