namespace quizz.Services;

public partial class TopicService
{
    public delegate ValueTask<Models.Topic> TopicReturningFunction();
    public delegate ValueTask<IEnumerable<Models.Topic>> TopicListReturningFunction();

    public async ValueTask<Models.Topic> TryCatch(TopicReturningFunction task)
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