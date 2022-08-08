using quizz.Models.Topic.Exceptions;

namespace quizz.Services;

public partial class TopicService
{
    public void ValidateQueryTopicsAsync(IQueryable<Entities.Topic>? topics)
    {
        if(topics is null)
        {
            throw new TopicServiceDependencyException();
        }

        if(topics.Any())
        {
            throw new TopicNotFoundException();
        }
    }
}