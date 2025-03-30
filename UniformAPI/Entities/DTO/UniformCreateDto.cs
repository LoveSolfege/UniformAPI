using System.ComponentModel.DataAnnotations;

namespace UniformAPI.Entities.DTO;

public class UniformCreateDto
{
    [Required]
    public string Barcode { get; set; }

    [Required]
    public int UniformTypeId { get; set; }

    [Required]
    public int UniformStatusId { get; set; }

    [Required]
    public int UniformDepartmentId { get; set; }
}