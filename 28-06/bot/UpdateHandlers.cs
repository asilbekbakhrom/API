using bot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

public class UpdateHandlers
{
    private readonly ILogger<UpdateHandlers> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public UpdateHandlers(
        ILogger<UpdateHandlers> logger,
        IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError("Error occured with Telegram Bot connection: {exception.Message}", exception);
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var handler = update.Type switch
        {
            UpdateType.Message => HandleNewMessageAsync(botClient, update.Message, cancellationToken),
            UpdateType.CallbackQuery => HandleCallbackQueryAsync(botClient, update.CallbackQuery, cancellationToken),
            _ => HandlerMessageAsync(botClient, update, cancellationToken)
        };

        try
        {
            await handler;
        }
        catch(Exception e)
        {
            await HandlePollingErrorAsync(botClient, e, cancellationToken);
        }
    }

    private async Task HandleCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery? callbackQuery, CancellationToken cancellationToken)
    {
        var from = callbackQuery?.From;
        if(Constants.Languages.ContainsKey(callbackQuery?.Data ?? string.Empty))
        {
            await UpdateLanguageAsync(callbackQuery.From, callbackQuery.Data);
        }
    }

    private async Task UpdateLanguageAsync(User from, string languageCode)
    {
        using var scope = _scopeFactory.CreateScope();
        var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

        var user = await userService.FindByAccountIdAsync(from.Id);

        user.LanguageCode = languageCode;

        await userService.UpdateAsync(user);
    }

    private async Task HandlerMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(
            update.Message.Chat.Id,
            $"Sorry, we dont support {update.Type} yet!",
            cancellationToken: cancellationToken);
    }

    private async Task HandleNewMessageAsync(ITelegramBotClient botClient, Message? message, CancellationToken cancellationToken)
    {
        await AddUserIfNotExistAsync(message);

        var from = message?.From;
        var chat = message?.Chat;

        _logger.LogInformation("{from.FirstName} said {message.Text}", from?.FirstName, message?.Text);

        if(message?.Text == "/start")
        {
            await botClient.SendTextMessageAsync(
                chat.Id,
                text: Constants.Greeting,
                replyToMessageId: message.MessageId,
                replyMarkup: MarkupHelpers.GetKeyboardMarkup(Constants.Languages, 3),
                cancellationToken: cancellationToken);
        }
    }

    private async Task AddUserIfNotExistAsync(Message? message)
    {
        ArgumentNullException.ThrowIfNull(message);

        var from = message?.From;

        using var scope = _scopeFactory.CreateScope();
        var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

        var user = new bot.Entity.User(
            firstname: from.FirstName,
            lastname: from.LastName,
            username: from.Username,
            chatId: message.Chat.Id,
            accountId: from.Id,
            phone: string.Empty,
            languageCode: from.LanguageCode
        );

        var result = await userService.AddAsync(user);
        if(!result.IsSuccess)
        {
            _logger.LogInformation("User adding failed: {result.ErrorMessage}", result.ErrorMessage);
        }
        else
        {
            _logger.LogInformation("New user added: {user.Id} {user.Firstname}", user.Id, user.Firstname);
        }
    }
}