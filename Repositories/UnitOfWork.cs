using quizz.Data;

namespace quizz.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public ITopicRepository Topics { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Topics = new TopicRepository(context);

    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public int Save()
        => _context.SaveChanges();
}