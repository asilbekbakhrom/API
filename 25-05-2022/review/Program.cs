var sonlar = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Console.WriteLine($"Birthday is {sonlar[0]:D2}-{sonlar[1]:D2}.");

// var oy = int.Parse(Console.ReadLine());
// var kun = int.Parse(Console.ReadLine());

// Console.WriteLine($"Bithday is {oy:D2}-{kun:D2}.");

// CTRL + ~ --> Terminal open/close