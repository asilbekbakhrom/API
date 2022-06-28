int t = int.Parse(Console.ReadLine() ?? string.Empty);

while(t-- > 0)
{
    var sonlar = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    var sonlarList = new List<int>(sonlar);

    var sum = sonlarList.Skip(1).Sum();
    var average = (float)sum / sonlarList[0];

    var countAboveAverage = sonlarList
        .Skip(1)
        .Count(son => son > average);
    
    Console.WriteLine($"{(float)countAboveAverage/sonlarList[0]:P3}");
}

