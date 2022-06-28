namespace delegates;

public class YoutubeDownloader
{
    public delegate void OnDownloadedDelegate();

    public OnDownloadedDelegate OnDownloaded { get; set; }

    public void Download()
    {
        Console.WriteLine($"Starting to download...");
        Task.Delay(2000).Wait();

        OnDownloaded?.Invoke();
        // if(OnDownloaded is not null)
        // {
        //     OnDownloaded();
        // }

        Console.WriteLine("Done");
    }
}