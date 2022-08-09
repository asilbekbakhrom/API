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
        catch(Exception)
        {
            throw;
        }
    }

    public async ValueTask<List<Topic>> TryCatch(TopicListReturningFunction task)
    {
        try
        {
            return await task();
        }
        catch(Exception)
        {
            throw;
        }
    }
}