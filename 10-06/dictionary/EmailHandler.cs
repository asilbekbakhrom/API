public class EmailHandler : MessageHandler
{
    public override void SendMessage(string message)
    {
        Console.WriteLine($"Sending Email message: {message}");
    }
}