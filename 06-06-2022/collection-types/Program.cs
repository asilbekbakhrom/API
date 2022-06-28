var sonlar = new List<short> {1,2, 3, 4, 5};

Print(2);
Print("Jellow world");
Print<short>(5);
Print(sonlar);


void Print<T>(T something)
{
    if(something is IEnumerable<int>)
    {
        (something as IEnumerable<int>)
            .ToList()
            .ForEach(Console.WriteLine);
    }
    else
    {
        Console.WriteLine($"{something}");
    }
}



// var array = new int[] { 1, 2, 3, 4, 5 };
// var thirdItem = array[2];    // array[2]
// var lastItem = array[^1];    // array[new Index(1, fromEnd: true)]

// Console.WriteLine($"{array[2]} {array[^0]} {^1}");


// var testCases = int.Parse(Console.ReadLine() ?? string.Empty);

// while(testCases-- > 0)
// {
//     var inputs = Console.ReadLine()?
//         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//         .Select(int.Parse)
//         .ToArray();
    
//     var sum = inputs?[1..].Sum();
//     var average = sum / (float)inputs[0];

//     var numberOfAboveAverage = inputs[1..].Count(score => score > average);

//     var aboveAveragePercentage = numberOfAboveAverage / (float)inputs[0];

//     Console.WriteLine($"{aboveAveragePercentage:P3}");
// }