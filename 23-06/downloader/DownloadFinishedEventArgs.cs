public class DownloadFinishedEventArgs : EventArgs
{
    public long ElapsedTime { get; internal set; }
    public double FileSizeInMb { get; internal set; }
    public string? FilePath { get; internal set; }
    public int SurahNumber { get; internal set; }
}