using quizz.Entities;

namespace quizz.Repositories;

public interface IQuizRepository
{
    IQueryable<Quiz> GetAll();
    ValueTask<Quiz?> GetByIdAsync(ulong id);
    ValueTask<Quiz> UpdateAsync(Quiz quiz);
    ValueTask<Quiz> InsertAsync(Quiz quiz);
    ValueTask<Quiz> DeleteAsync(Quiz quiz);
}