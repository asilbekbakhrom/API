var quranDownloader = new QuranDownloader();

quranDownloader.OnFailed += HandleFailed;
quranDownloader.OnFinished += HandleFinished;

quranDownloader.StartDownloading(2);

Console.ReadKey();

void HandleFinished(object? sender, DownloadFinishedEventArgs e)
{
    Console.WriteLine("Successfully downloaded surah!");
    Console.WriteLine($"Surah number: {e.SurahNumber}");
    Console.WriteLine($"File size: {e.FileSizeInMb:F2}MB");
    Console.WriteLine($"File Location: {e.FilePath}");
    
}

void HandleFailed(object? sender, DownloadFailedEventArgs e)
{
    Console.WriteLine($"Failed to download the surah. \n{e.ErrorMessage}");
}