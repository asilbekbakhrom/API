using System.ComponentModel.DataAnnotations;

namespace databases.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string? Fullname { get; set; }
    public DateTime Birthdate { get; set; }
    [Required]
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public double Grade { get; set; }
    public ELanguage Language { get; set; }
}