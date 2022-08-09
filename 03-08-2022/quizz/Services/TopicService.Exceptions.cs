using quizz.Models.Topic;

namespace quizz.Services;

public partial class TopicService
{
    public delegate ValueTask<Topic> TopicReturningFunction();
    public delegate ValueTask<List<Topic>> TopicListReturningFunction();

    public async ValueTask<Topic> TryCatch(TopicReturningFunction task)
    {
        try
        {
            return await task();
        }
        catch(Exception ex)
        {
            _logger.LogError($"Error occured at {nameof(TopicService)}: {ex.Message}", ex);

            throw;
        }
    }


    public async ValueTask<List<Topic>> TryCatch(TopicListReturningFunction task)
    {
        try
        {
            return await task();
        }
        catch(Exception ex)
        {
            _logger.LogError($"Error occured at {nameof(TopicService)}: {ex.Message}", ex);

            throw;
        }
    }
}