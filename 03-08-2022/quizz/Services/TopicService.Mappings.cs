namespace quizz.Services;

public partial class TopicService
{
    public Entities.Topic ToEntity(Models.Topic model)
    => new(
        name: model.Name ?? throw new NullReferenceException(nameof(model.Name)),
        description: model.Description ?? throw new NullReferenceException(nameof(model.Description)),
        difficulty: ToEntity(model.Difficulty));

    public Models.Topic ToModel(Entities.Topic entity)
    => new()
    {
        Name = entity.Name,
        Description = entity.Description,
        Difficulty = ToModel(entity.Difficulty)
    };

    public Models.ETopicDifficulty ToModel(Entities.ETopicDifficulty entity)
    => entity switch
    {
        Entities.ETopicDifficulty.Beginner => Models.ETopicDifficulty.Beginner,
        Entities.ETopicDifficulty.Intermediate => Models.ETopicDifficulty.Intermediate,
        _ => Models.ETopicDifficulty.Advanced,
    };

    public Entities.ETopicDifficulty ToEntity(Models.ETopicDifficulty model)
    => model switch
    {
        Models.ETopicDifficulty.Beginner => Entities.ETopicDifficulty.Beginner,
        Models.ETopicDifficulty.Intermediate => Entities.ETopicDifficulty.Intermediate,
        _ => Entities.ETopicDifficulty.Advanced,
    };
}