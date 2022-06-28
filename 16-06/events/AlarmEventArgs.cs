public class AlarmEventArgs : EventArgs
{
    public double ElapsedMilliseconds 
    {
        get => (EndTime - StartTime).TotalMilliseconds;
    }

    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }

    public AlarmEventArgs(DateTime startTime, DateTime endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
}