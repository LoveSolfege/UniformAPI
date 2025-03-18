namespace UniformAPI.Entities;

public class UniformDepartment
{
	public int Id { get; set; }
	public string Name { get; set; }
	
	public ICollection<Uniform> Uniforms { get; set; }
}