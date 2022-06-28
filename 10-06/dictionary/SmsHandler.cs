public class SmsHandler : MessageHandler
{

    public override void SendMessage(string message)
    {
        Console.WriteLine($"Sending SMS message: {message}");
    }
}