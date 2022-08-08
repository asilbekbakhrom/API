namespace quizz.Services;

public interface ITopicService
{
    ValueTask<IEnumerable<Models.Topic>> GetAllPaginatedAsync(int page, int limit);
    ValueTask<Models.Topic> GetByIdAsync(ulong id);
    ValueTask<Models.Topic> FindByNameAsync(string name);
    ValueTask<Models.Topic> RemoveAsync(Models.Topic topic);
    ValueTask<Models.Topic> CreateAsync(Models.Topic topic);
    ValueTask<Models.Topic> UpdateAsync(Models.Topic topic);

}