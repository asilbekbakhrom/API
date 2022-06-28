public static class StringExtensions
{
    public static int[] ToIntArray(this String text)
    {
        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
    }
}