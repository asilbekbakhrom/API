using Microsoft.AspNetCore.Mvc;
using quizz.Dtos.Quizes;

namespace quizz.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizesController : ControllerBase
{

    [HttpPost]
    public IActionResult PostAsync([FromBody]PostQuizDto model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        if(model.Categories?.Count() < 1)
        {
            ModelState.AddModelError(nameof(PostQuizDto.Categories), "At least one category is required.");

            return BadRequest(ModelState);
        }

        return Ok();
    }
}