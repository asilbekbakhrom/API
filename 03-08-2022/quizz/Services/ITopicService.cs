using quizz.Models.Topic;

namespace quizz.Services;

public interface ITopicService
{
    ValueTask<List<Topic>> GetAllPaginatedTopicsAsync(int page, int limit);
    ValueTask<Topic> GetByIdAsync(ulong id);
    ValueTask<Topic> FindByNameAsync(string name);
    ValueTask<Topic> RemoveAsync(Topic topic);
    ValueTask<Topic> CreateAsync(Topic topic);
    ValueTask<Topic> UpdateAsync(Topic topic);

}