using bot.Entity;

namespace bot.Services;

public interface IUserService
{
    Task<User?> FindByChatIdAsync(long chatId);
    Task<User?> FindByAccountIdAsync(long accountId);
    Task<User?> FindByUsername(string username);
    Task<(bool IsSuccess, string? ErrorMessage)> AddAsync(User user);
    Task<(bool IsSuccess, string? ErrorMessage)> UpdateAsync(User user);
}