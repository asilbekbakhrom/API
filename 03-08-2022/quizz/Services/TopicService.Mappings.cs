using quizz.Models.Topic;

namespace quizz.Services;

public partial class TopicService
{
    public Entities.Topic ToEntity(Topic model)
    => new(
        name: model.Name ?? throw new NullReferenceException(nameof(model.Name)),
        description: model.Description ?? throw new NullReferenceException(nameof(model.Description)),
        difficulty: ToEntity(model.Difficulty));

    public Topic ToModel(Entities.Topic entity)
    => new()
    {
        Name = entity.Name,
        Description = entity.Description,
        Difficulty = ToModel(entity.Difficulty)
    };

    public ETopicDifficulty ToModel(Entities.ETopicDifficulty entity)
    => entity switch
    {
        Entities.ETopicDifficulty.Beginner => ETopicDifficulty.Beginner,
        Entities.ETopicDifficulty.Intermediate => ETopicDifficulty.Intermediate,
        _ => ETopicDifficulty.Advanced,
    };

    public Entities.ETopicDifficulty ToEntity(ETopicDifficulty model)
    => model switch
    {
        ETopicDifficulty.Beginner => Entities.ETopicDifficulty.Beginner,
        ETopicDifficulty.Intermediate => Entities.ETopicDifficulty.Intermediate,
        _ => Entities.ETopicDifficulty.Advanced,
    };
}