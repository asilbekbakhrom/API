// var builder = WebApplication.CreateBuilder(args);

// var app = builder.Build();

// app.MapGet("/", () => "Bot is alive 🤖!");

// app.Run();

using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

var botClient = new TelegramBotClient("5513868507:AAFTCpxB6F0_QSe0F-wCVEKLvNnSf5BfZMw");


botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: null,
    CancellationToken.None);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

Console.ReadLine();

async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
{

    
    if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
    {
        var chatId = update.Message.Chat.Id;

        Console.WriteLine($"{update.Message.From.FirstName} said {update.Message.Text}");

        await client.SendTextMessageAsync(
            chatId: chatId,
            text: $"*Hello* `{update?.Message?.From?.FirstName}`",
            parseMode: Telegram.Bot.Types.Enums.ParseMode.MarkdownV2);
    }
    else if(update.Type == Telegram.Bot.Types.Enums.UpdateType.EditedMessage
    && update.EditedMessage is not null)
    {
    Console.WriteLine($"{System.Text.Json.JsonSerializer.Serialize(update)}");
        var chatId = update.Message.Chat.Id;

        Console.WriteLine($"{update.EditedMessage.From.FirstName} edited message to {update.EditedMessage.Text}");

        await client.SendTextMessageAsync(
            chatId: chatId,
            text: $"You updated a message.",
            parseMode: Telegram.Bot.Types.Enums.ParseMode.MarkdownV2);
    }
}

Task HandlePollingErrorAsync(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
{
    throw new NotImplementedException();
}