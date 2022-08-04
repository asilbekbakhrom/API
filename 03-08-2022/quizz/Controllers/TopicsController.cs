using Microsoft.AspNetCore.Mvc;
using quizz.Dtos;
using quizz.Dtos.Topic;
using quizz.Repositories;

namespace quizz.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopicsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TopicsController> _logger;

    public TopicsController(
        IUnitOfWork unitOfWork,
        ILogger<TopicsController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase<List<Topic>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetTopics([FromQuery]Pagination pagination)
    {
        var topicDtos = _unitOfWork.Topics.GetAll()
            .Skip((pagination.Page - 1) * pagination.Limit)
            .Take(pagination.Limit)
            .Select(ToDto)
            .ToList();

        var response =  new ResponseBase<List<Topic>>()
        {
            Data = topicDtos,
            Pagination = pagination
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostTopic(CreateTopicDto model)
    {
        if(!ModelState.IsValid) return BadRequest(model);

        var entity = ToEntity(model);

        try
        {
            var result = await _unitOfWork.Topics.Add(entity);
            _unitOfWork.Save();

            return Created("/", ToDto(result));
        }
        catch(Exception e)
        {
            // TO-DO: we want to handle conflict error
            return BadRequest(e.Message);
        }
    }

    private Entities.Topic ToEntity(CreateTopicDto dto)
        => new(
            dto.Name!,
            dto.Description!,
            dto.Difficulty switch
            {
                ETopicDifficulty.Beginner => Entities.ETopicDifficulty.Beginner,
                ETopicDifficulty.Intermidiate => Entities.ETopicDifficulty.Intermidiate,
                _ => Entities.ETopicDifficulty.Advanced,
            });

    private Topic ToDto(Entities.Topic entity)
    {
        return new Topic()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Difficulty = entity.Difficulty.ToString(),
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
}