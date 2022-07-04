using bot.Data;
using bot.Services;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BotDbContext>(options
    => options.UseSqlite(builder.Configuration.GetConnectionString("BotConnection")));

var token = builder.Configuration.GetValue("BotToken", string.Empty);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton(p => new TelegramBotClient(token));
builder.Services.AddSingleton<UpdateHandlers>();
builder.Services.AddHostedService<BotBackgroundService>();

var app = builder.Build();

app.MapGet("/", () => "Bot is working 🤖");

app.Run();