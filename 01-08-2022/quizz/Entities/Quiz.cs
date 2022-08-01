namespace quizz.Entities;

public class Quiz : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Categories { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }

    [Obsolete("Used only by EF Core.")]
    public Quiz() { }

    public Quiz(string name, string description, string categories, DateTimeOffset startTime, DateTimeOffset endTime)
    {
        Name = name;
        Description = description;
        Categories = categories;
        StartTime = startTime;
        EndTime = endTime;
    }
}