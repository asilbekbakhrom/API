using Microsoft.AspNetCore.Mvc;
using movies.Dtos;

namespace movies.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly ILogger<MoviesController> _logger;

    public MoviesController(ILogger<MoviesController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult CreateMovie([FromForm]CreateMovieDto model)
    {
        // if(model.Genres is null || model.Genres.Count < 1)
        // {
        //     ModelState.AddModelError(nameof(model.Genres), "At least one genre is required");
        //     return BadRequest(ModelState);
        // }

        // var genres = EMovieGenre.None;
        // foreach(var genre in model.Genres)
        // {
        //     if(!Enum.TryParse<EMovieGenre>(genre, out var g))
        //         ModelState.AddModelError(nameof(model.Genres), $"Couldnt find genre named {genre}");

        //     genres |= g;
        // }

        // if(!ModelState.IsValid)
        // {
        //     return BadRequest(ModelState);
        // }

        using var imageSteam = new MemoryStream();
        model.BannerImage.CopyTo(imageSteam);

        var imageString = Convert.ToBase64String(imageSteam.ToArray());

        return File(Convert.FromBase64String(imageString), model.BannerImage.ContentType);
    }
    
}