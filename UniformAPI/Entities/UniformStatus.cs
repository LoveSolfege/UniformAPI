namespace UniformAPI.Entities;

public class UniformStatus
{
	public int Id { get; set; }
	public string Status { get; set; }
	
	public ICollection<Uniform> Uniforms { get; set; }
}