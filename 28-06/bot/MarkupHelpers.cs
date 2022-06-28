using Telegram.Bot.Types.ReplyMarkups;

public static class MarkupHelpers
{
    public static InlineKeyboardMarkup GetKeyboardMarkup(Dictionary<string, string> keys, int columns = 2)
    {
        int row = 0;

        var buttonMatrix = new List<List<InlineKeyboardButton>>();

        while(keys.Skip(row).Take(columns)?.Count() > 0)
        {
            var buttons = keys.Skip(row * columns).Take(columns).Select(k => InlineKeyboardButton.WithCallbackData(k.Value, k.Key)).ToList();

            buttonMatrix.Add(buttons);
            
            row++;
        }

        return new InlineKeyboardMarkup(buttonMatrix.ToArray());
    }
}