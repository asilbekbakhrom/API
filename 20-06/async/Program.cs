using System.Diagnostics;

var bigStopwatch = new Stopwatch();
bigStopwatch.Start();

var b1Task = MakeBreakfastAsync();
// var b2Task = MakeBreakfastAsync();
// var b3Task = MakeBreakfastAsync();
// var b4Task = MakeBreakfastAsync();
// var b5Task = MakeBreakfastAsync();

var tasks = new [] { b1Task };

System.Console.WriteLine($"{b1Task.Exception?.Message}");

await Task.WhenAll(tasks);

Console.WriteLine($"All breakfasts are ready in {bigStopwatch.ElapsedMilliseconds}ms");

static async Task MakeBreakfastAsync()
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    Console.WriteLine($"Starting to make breakfast.\n\n");

    var coffee = PourCoffee();
    Console.WriteLine($"Coffee is ready after {stopwatch.ElapsedMilliseconds:F0}ms");

    var eggs = FryEggsAsync(5);

    var toasts = MakeToastWithJamAndButterAsync(3);

    var tasks = Task.WhenAll(new [] { eggs, toasts });
    await tasks;

    Console.WriteLine($"Everything is ready after {stopwatch.ElapsedMilliseconds:F0}ms");
}

static async Task<string> MakeToastWithJamAndButterAsync(int count)
{
    Console.WriteLine($"Toasting {count} bread.");
    await Task.Delay(1000);

    for(int i = 1; i <= count; i++)
    {
        ApplyJam();
        ApplyButter();
    }

    Console.WriteLine($"{count} toasts are ready.");
    
    return "toasts";
}

static void ApplyJam()
    => Console.WriteLine($"Appling jam to toast.");

static void ApplyButter()
    => Console.WriteLine($"Appling butter to toast.");

static async Task<string> FryEggsAsync(int count)
{
    try
    {
        Console.WriteLine($"Heating the pan");
        await Task.Delay(3000);

        throw new Exception("Pan is on fire");

        for(int i = 1; i <= count; i ++)
        {
            Console.WriteLine($"Cracking Egg #{i}");
        }

        Console.WriteLine($"Frying {count} eggs.");
        await Task.Delay(3000);
        Console.WriteLine($"{count} eggs are ready.");
    }
    catch(Exception e)
    {
        Console.WriteLine($"Frying egg failed. Error is: {e.Message}");
    }

    return "eggs";
}

static string PourCoffee()
{
    Console.WriteLine($"Pouring a cup of coffee.");

    return "Coffee";
}