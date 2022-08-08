using quizz.Models;
using quizz.Repositories;

namespace quizz.Services;

public partial class TopicService : ITopicService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TopicService> _logger;

    public TopicService(IUnitOfWork unitOfWork, ILogger<TopicService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public ValueTask<Topic> CreateAsync(Topic topic)
    => TryCatch(async () =>
    {
        var createdTopic = await _unitOfWork.Topics.AddAsync(ToEntity(topic));

        return ToModel(createdTopic);
    });

    public ValueTask<Topic> FindByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<IEnumerable<Topic>> GetAllPaginatedAsync(int page, int limit)
    => TryCatch(async () =>
    {
        var topics = _unitOfWork.Topics.GetAll();

        ValidateQueryTopics(topics);
    });

    public ValueTask<Topic> GetByIdAsync(ulong id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Topic> RemoveAsync(Topic topic)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Topic> UpdateAsync(Topic topic)
    {
        throw new NotImplementedException();
    }
}