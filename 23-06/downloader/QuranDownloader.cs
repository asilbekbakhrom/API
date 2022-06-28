using System.Diagnostics;

public class QuranDownloader
{
    private readonly QuranClient _client;
    public event EventHandler<DownloadFailedEventArgs>? OnFailed;
    public event EventHandler<DownloadFinishedEventArgs>? OnFinished;
    
    private const string _baseUrl = "https://server7.mp3quran.net/s_gmd";

    public QuranDownloader()
    {
        _client = new QuranClient(_baseUrl);
    }

    public void StartDownloading(int surahNumber)
    {
        Task.Run(async () => 
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            try
            {
                var stream = await _client.DownloadSurahAsync(surahNumber);

                Console.WriteLine($"Download finished {stream.Length}");
                

                var sizeInMb = (double)stream.Length / (1024 * 1024);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{surahNumber:D3}.mp3");

                using var fileStream = File.Create(filePath);
                await stream.CopyToAsync(fileStream);

                OnFinished?.Invoke(this, new DownloadFinishedEventArgs()
                {
                    ElapsedTime = stopwatch.ElapsedMilliseconds,
                    FileSizeInMb = sizeInMb,
                    FilePath = filePath,
                    SurahNumber = surahNumber
                });
            }
            catch(Exception e)
            {
                OnFailed?.Invoke(this, new DownloadFailedEventArgs()
                {
                    ErrorMessage = e.Message
                });
            }
        });
    }
}