public class QuranClient
{
    private readonly string _baseUrl;

    public QuranClient(string baseUrl)
    {
        if(string.IsNullOrWhiteSpace(baseUrl))
            throw new ArgumentNullException($"{nameof(baseUrl)} is empty");

        _baseUrl = baseUrl;
    }

    public async Task<Stream> DownloadSurahAsync(int surahNumber)
    {
        if(surahNumber < 1 || surahNumber > 114)
            throw new ArgumentOutOfRangeException($"Surah number {surahNumber} is out of range");

        var surahUrl = string.Format($"{_baseUrl}/{surahNumber:D3}.mp3");

        using var client = new HttpClient();

        var array = await client.GetByteArrayAsync(surahUrl);

        return new MemoryStream(array);
    }
}