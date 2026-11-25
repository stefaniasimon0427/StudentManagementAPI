using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models.DTO;

public class AddStudentDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(15)]
    public string Phone { get; set; } = string.Empty;

    [Required]
    public int Age { get; set; }

    [Required]
    [MaxLength(100)]
    public string Course { get; set; } = string.Empty;

    [MaxLength(250)]
    public string? Address { get; set; }
}