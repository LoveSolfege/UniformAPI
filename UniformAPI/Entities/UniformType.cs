namespace UniformAPI.Entities;

public class UniformType
{
	public int Id { get; set; }
	public string Type { get; set; }
	
	public ICollection<Uniform> Uniforms { get; set; }
}