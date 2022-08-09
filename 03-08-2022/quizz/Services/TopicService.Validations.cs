using quizz.Models.Topic.Exceptions;

namespace quizz.Services;

public partial class TopicService
{
    public void ValidateQueryTopics(IQueryable<Entities.Topic>? topics)
    {
        if(topics is null)
        {
            throw new TopicServiceDependencyException();
        }

        if(!topics.Any())
        {
            throw new TopicNotFoundException();
        }
    }

    public void ValidateName(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new TopicServiceValidationException(nameof(Models.Topic.Topic.Name));
        }
    }

    public void ValidateTopicModel(Models.Topic.Topic model)
    {
        if(model is null)
            throw new TopicServiceValidationException();
    }
}