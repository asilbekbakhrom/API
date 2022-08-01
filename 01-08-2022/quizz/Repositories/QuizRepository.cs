using quizz.Data;
using quizz.Entities;

namespace quizz.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly QuizDbContext _context;

    public QuizRepository(QuizDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Quiz> DeleteAsync(Quiz quiz)
    {
        var entityEntry = _context.Quizes.Remove(quiz);
        await _context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public IQueryable<Quiz> GetAll()
        => _context.Quizes;

    public async ValueTask<Quiz?> GetByIdAsync(ulong id)
        => await _context.Quizes.FindAsync(id);

    public async ValueTask<Quiz> InsertAsync(Quiz quiz)
    {
        var entityEntry = await _context.Quizes.AddAsync(quiz);
        await _context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<Quiz> UpdateAsync(Quiz quiz)
    {
        var entityEntry  = _context.Quizes.Update(quiz);
        await _context.SaveChangesAsync();

        return entityEntry.Entity;
    }
}