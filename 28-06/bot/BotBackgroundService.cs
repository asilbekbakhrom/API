using Telegram.Bot;

public class BotBackgroundService : BackgroundService
{
    private readonly ILogger<BotBackgroundService> _logger;
    private readonly TelegramBotClient _botClient;
    private readonly UpdateHandlers _updateHandlers;

    public BotBackgroundService(
        ILogger<BotBackgroundService> logger,
        TelegramBotClient botClient,
        UpdateHandlers updateHandlers)
    {
        _logger = logger;
        _botClient = botClient;
        _updateHandlers = updateHandlers;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _botClient.StartReceiving(
            _updateHandlers.HandleUpdateAsync,
            _updateHandlers.HandlePollingErrorAsync,
            new Telegram.Bot.Polling.ReceiverOptions()
            {
                ThrowPendingUpdates = true
            }, 
            stoppingToken);

        var me = await _botClient.GetMeAsync(stoppingToken);

        _logger.LogInformation("{me.FirstName} started successfully!", me.FirstName);
    }
}