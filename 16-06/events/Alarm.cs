public class Alarm
{
    private DateTime _alarmTime;

    public event EventHandler<AlarmEventArgs> OnAlarm;

    public Alarm(DateTime alarmTime)
    {
        _alarmTime = alarmTime;
    }
    
    public async Task Start()
    {
        // while(_alarmTime > DateTime.Now);

        await Task.Delay(_alarmTime - DateTime.Now);

        OnAlarm?.Invoke(this, new AlarmEventArgs(_alarmTime, DateTime.Now));
    }
}