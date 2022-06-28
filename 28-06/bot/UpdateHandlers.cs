using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

public class UpdateHandlers
{
    private readonly ILogger<UpdateHandlers> _logger;

    public UpdateHandlers(ILogger<UpdateHandlers> logger)
    {
        _logger = logger;
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

    private async Task HandlerMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(
            update.Message.Chat.Id,
            $"Sorry, we dont support {update.Type} yet!",
            cancellationToken: cancellationToken);
    }

    private async Task HandleNewMessageAsync(ITelegramBotClient botClient, Message? message, CancellationToken cancellationToken)
    {
        var from = message?.From;
        var chat = message?.Chat;

        _logger.LogInformation("{from.FirstName} said {message.Text}", from?.FirstName, message?.Text);

        if(message?.Text == "/start")
        {
            await botClient.SendTextMessageAsync(
                chat.Id,
                text: Constants.Greeting,
                replyToMessageId: message.MessageId,
                replyMarkup: MarkupHelpers.GetKeyboardMarkup(
                    new Dictionary<string, string>
                    {
                        { "ru", "Russian" },
                        { "en", "English" },
                        { "uz", "Uzbek" },
                        { "it", "Italian" },
                        { "ar", "Arabic" }
                    }, 3
                ),
                cancellationToken: cancellationToken);
        }
    }

    // private async Task SendKeyboard(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    // {
    //     await botClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

    //         // Simulate longer running task
    //         await Task.Delay(500);

            

    //         await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
    //                                                     text: "Choose",
    //                                                     replyMarkup: inlineKeyboard);
    // }
}