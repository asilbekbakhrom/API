using System.ComponentModel.DataAnnotations;

namespace databases.Dtos;

public class Student
{
    [MaxLength(255)]
    public string? Fullname { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }

    [Required]
    [Phone]
    public string? Phone { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public double Grade { get; set; }
    public ELanguage Language { get; set; }
}