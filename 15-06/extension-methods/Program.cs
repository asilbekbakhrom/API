var sonlar = Console.ReadLine()?.ToIntArray();
// var sonlar2 = Console.ReadLine()?.ToIntArray();

sonlar?.ToList().ForEach(Console.WriteLine);
