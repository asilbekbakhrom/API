using bot.Data;
using bot.Entity;
using Microsoft.EntityFrameworkCore;

namespace bot.Services;

public class UserService : IUserService
{
    private readonly BotDbContext _context;
    private readonly ILogger<UserService> _logger;

    public UserService(
        BotDbContext context,
        ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<(bool IsSuccess, string? ErrorMessage)> AddAsync(User user)
    {
        if(await _context.Users.AnyAsync(u => u.Id == user.Id || u.ChatId == user.ChatId || u.AccountId == user.AccountId))
            return (false, "User already exists");

        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e.Message);
        }
    }

    public async Task<User?> FindByChatIdAsync(long chatId)
        => await _context.Users.FirstOrDefaultAsync(u => u.ChatId == chatId);
    
    public async Task<User?> FindByAccountIdAsync(long accountId)
        => await _context.Users.FirstOrDefaultAsync(u => u.AccountId == accountId);

    public async Task<User?> FindByUsername(string username)
        => await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

    public async Task<(bool IsSuccess, string? ErrorMessage)> UpdateAsync(User user)
    {
        try
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e.Message);
        }
    }
}