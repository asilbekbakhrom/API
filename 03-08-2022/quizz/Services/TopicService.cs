using Microsoft.EntityFrameworkCore;
using quizz.Models.Topic;
using quizz.Models.Topic.Exceptions;
using quizz.Repositories;
using quizz.Utils;

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
    => TryCatch(async () =>
    {
        ValidateName(name);

        var nameHash = name.Sha256();

        var topic = await _unitOfWork.Topics.GetAll().FirstOrDefaultAsync(t => t.NameHash == nameHash);

        return ToModel(topic ?? throw new TopicNotFoundException());
    });

    public ValueTask<List<Topic>> GetAllPaginatedTopicsAsync(int page, int limit)
    => TryCatch(async () =>
    {
        var topics = _unitOfWork.Topics.GetAll();

        ValidateQueryTopics(topics);

        return  await topics
            .Skip((page - 1) * limit)
            .Take(limit)
            .Select(e => ToModel(e))
            .ToListAsync();
    });

    public ValueTask<Topic> GetByIdAsync(ulong id)
    => TryCatch(async () =>
    {
        var topic = await _unitOfWork.Topics.GetAll().FirstOrDefaultAsync(t => t.Id == id);

        return ToModel(topic ?? throw new TopicNotFoundException());
    });

    public ValueTask<Topic> RemoveAsync(Topic topic)
    => TryCatch(async () => 
    {
        ValidateTopicModel(topic);

        var topicEntity = _unitOfWork.Topics.GetById(topic.Id);

        var existingTopic = await _unitOfWork.Topics.Remove(topicEntity ?? throw new TopicNotFoundException());

        return ToModel(existingTopic);
    });

    public ValueTask<Topic> UpdateAsync(Topic topic)
    => TryCatch(async () => 
    {
        ValidateTopicModel(topic);

        var topicEntity = _unitOfWork.Topics.GetById(topic.Id);

        var existingTopic = await _unitOfWork.Topics.Update(topicEntity ?? throw new TopicNotFoundException());

        return ToModel(existingTopic);
    });
}