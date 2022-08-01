using System.ComponentModel.DataAnnotations;

namespace quizz.Dtos.Quizes;

public class PostQuizDto
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }
    
    [Required]
    public string[]? Categories { get; set; }
    
    [Required]
    public DateTimeOffset StartTime { get; set; }
    
    [Required]
    public DateTimeOffset EndTime { get; set; } 
}