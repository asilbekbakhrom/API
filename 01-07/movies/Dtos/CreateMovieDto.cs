using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using movies.Attributes;

namespace movies.Dtos;

public class CreateMovieDto
{
    [Required]
    [StringLength(maximumLength: 255, MinimumLength = 5)]
    public string? Title { get; set; }
    [Required]
    [Range(typeof(DateTime), "1/1/1950", "1/1/2023")]
    public DateTime ReleaseDate { get; set; }
    [Required]
    public EMovieGenre Genres { get; set; }
    public string? Description { get; set; }
    [Required]
    [Range(1, 10)]
    public double Imdb { get; set; }
    public IFormFile? BannerImage { get; set; }
}