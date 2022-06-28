var alarm = new Alarm(DateTime.Now.AddSeconds(5));

Console.WriteLine($"Alarm is set!");
alarm.OnAlarm += HandleBudilnik;

alarm.Start();

Console.WriteLine($"Alarm is started");

Console.ReadLine();


void HandleBudilnik(object? sender, AlarmEventArgs e)
{
    Console.WriteLine($"Alarm is ringing after {e.ElapsedMilliseconds}ms");
}