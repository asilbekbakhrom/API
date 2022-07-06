using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace bot.Services;

public partial class BotUpdateHandler
{
    private async Task HandleMessageAsync(ITelegramBotClient client, Message? message, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(message);

        var from = message.From;
        _logger.LogInformation("Received message from {from.Firstname}", from?.FirstName);

        var handler = message.Type switch
        {
            MessageType.Text => HandleTextMessageAsync(client, message, token),
            _ => HandleUnknownMessageAsync(client, message, token)
        };
        
        await handler;
    }

    private Task HandleUnknownMessageAsync(ITelegramBotClient client, Message message, CancellationToken token)
    {
        _logger.LogInformation("Received message type {message.Type}", message.Type);

        return Task.CompletedTask;
    }

    private async Task HandleTextMessageAsync(ITelegramBotClient client, Message message, CancellationToken token)
    {
        var from = message.From;
        _logger.LogInformation("From: {from.Firstname}", from?.FirstName);

        if(message.Text.Contains("uz", StringComparison.CurrentCultureIgnoreCase))
        {
            await _userService.UpdateLanguageCodeAsync(from.Id, "uz-Uz");
        }
        else if(message.Text.Contains("en", StringComparison.CurrentCultureIgnoreCase))
        {
            await _userService.UpdateLanguageCodeAsync(from.Id, "en-Us");
        }
        else
        {
            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: _localizer["greeting"],
                replyToMessageId: message.MessageId, 
                cancellationToken: token);
        }
    }
}