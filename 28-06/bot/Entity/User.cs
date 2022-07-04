namespace bot.Entity;

public class User
{
    public Guid Id { get; set; }
    public long AccountId { get; set; }
    public long ChatId { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Phone { get; set; }
    public bool Blocked { get; set; }
    public string? LanguageCode { get; set; }
    public DateTimeOffset JoinedAt { get; set; }
    public DateTimeOffset LastInteractionAt { get; set; }

    [Obsolete("Used only for model binding.", true)]
    public User() { }

    public User(long accountId, long chatId, string? firstname, string? lastname, string? username, string? phone, string languageCode)
    {
        Id = Guid.NewGuid();
        JoinedAt = DateTimeOffset.UtcNow;
        LastInteractionAt = JoinedAt;

        AccountId = accountId;
        ChatId = chatId;
        Firstname = firstname;
        Lastname = lastname;
        Username = username;
        Phone = phone;
        LanguageCode = languageCode;
    }
}