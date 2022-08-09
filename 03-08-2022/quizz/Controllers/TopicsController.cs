using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using quizz.Dtos;
using quizz.Dtos.Topic;
using quizz.Repositories;
using quizz.Services;

namespace quizz.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopicsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TopicsController> _logger;
    private readonly ITopicService _topicService;

    public TopicsController(
        ITopicService topicService,
        ILogger<TopicsController> logger)
    {
        _logger = logger;
        _topicService = topicService;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase<List<Topic>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTopics([FromQuery]Pagination pagination)
    {
        var topicDtos = (await _topicService
            .GetAllPaginatedTopicsAsync(pagination.Page, pagination.Limit))
            .Select(ToDto)
            .ToList();

        var response =  new ResponseBase<List<Topic>>()
        {
            Data = topicDtos,
            Pagination = pagination
        };

        return Ok(response);
    }

    // [HttpGet]
    // [Route("{id}")]
    // [Produces("application/json")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase<Topic>))]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public IActionResult GetTopic([FromRoute]ulong id)
    // {
    //     var response = new ResponseBase<Topic>();
    //     var topic = _unitOfWork.Topics.GetById(id);

    //     if(topic is null)
    //     {
    //         response.Error = new Error()
    //         {
    //             Message = $"Topic with ID {id} not found",
    //             Code = StatusCodes.Status404NotFound
    //         };

    //         return NotFound(response);
    //     }

    //     response.Data = ToDto(topic);

    //     return Ok(response);
    // }
    

    // [HttpPost]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<IActionResult> PostTopic(CreateTopicDto model)
    // {
    //     if(!ModelState.IsValid) return BadRequest(model);

    //     var entity = ToEntity(model);

    //     try
    //     {
    //         var result = await _unitOfWork.Topics.Add(entity);
    //         _unitOfWork.Save();

    //         return CreatedAtAction(nameof(GetTopic), new { id = result.Id }, ToDto(result));
    //     }
    //     catch(SqliteException sqlException)
    //     {
    //         return BadRequest($"Database exception: {sqlException?.InnerException?.Message}");
    //     }
    //     catch(Exception e)
    //     {
    //         // TO-DO: we want to handle conflict error
    //         return BadRequest(e.Message);
    //     }
    // }

    // [HttpDelete("{id}")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase<Topic>))]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public IActionResult DeleteTopic(ulong id)
    // {
    //     var response  = new ResponseBase<Topic>();

    //     var topic = _unitOfWork.Topics.GetById(id);
    //     if(topic is null)
    //     {
    //         response.Error = new Error()
    //         {
    //             Message = $"Topic with ID {id} not found",
    //             Code = StatusCodes.Status404NotFound
    //         };

    //         return NotFound(response);
    //     }

    //     var deletedTopic = _unitOfWork.Topics.Remove(topic);
    //     _unitOfWork.Save();
    //     response.Data = ToDto(deletedTopic);

    //     return Ok(response);
    // }

    // [HttpPut("{id}")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase<Topic>))]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public IActionResult UpdateTopic([FromRoute]ulong id, [FromBody]UdpateTopicDto model)
    // {
    //     if(!ModelState.IsValid)
    //     {
    //         return BadRequest(model);
    //     }

    //     var response  = new ResponseBase<Topic>();

    //     var topic = _unitOfWork.Topics.GetById(id);
    //     if(topic is null)
    //     {
    //         response.Error = new Error()
    //         {
    //             Message = $"Topic with ID {id} not found",
    //             Code = StatusCodes.Status404NotFound
    //         };

    //         return NotFound(response);
    //     }

    //     topic.Name = model.Name;
    //     topic.Description = model.Description;
    //     topic.Difficulty = model.Difficulty switch
    //     {
    //         ETopicDifficulty.Beginner => Entities.ETopicDifficulty.Beginner,
    //         ETopicDifficulty.Intermidiate => Entities.ETopicDifficulty.Intermidiate,
    //         _ => Entities.ETopicDifficulty.Advanced,
    //     };

    //     var updatedTopic = _unitOfWork.Topics.Update(topic);
    //     _unitOfWork.Save();

    //     response.Data = ToDto(topic);
    //     return Ok(response);
    // }

    // private Entities.Topic ToEntity(CreateTopicDto dto)
    //     => new(
    //         dto.Name!,
    //         dto.Description!,
    //         dto.Difficulty switch
    //         {
    //             ETopicDifficulty.Beginner => Entities.ETopicDifficulty.Beginner,
    //             ETopicDifficulty.Intermidiate => Entities.ETopicDifficulty.Intermidiate,
    //             _ => Entities.ETopicDifficulty.Advanced,
    //         });

    private Topic ToDto(Models.Topic.Topic entity)
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