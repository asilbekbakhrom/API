using System.Diagnostics;
using System.Numerics;

public class Program
{
    public static async Task Main()
    {
        var task1 = Task.Run(() =>
        {
            for(int i = 0; i < 1000000000; i++)
            {
                Console.Write($"{1} "); 
            }
        });

        var task2 = Task.Run(() =>
        {
            for(int i = 0; i < 1000000000; i++)
            {
                Console.Write($"{2} "); 
            }
        });

        await Task.WhenAll(new [] { task1, task2 });
    }

    public static void Main1(string[] args)
    {
        var x  = 1234567;

        Console.WriteLine($"Let's find {x}th fibonacci.");

        var result = Calculate(x);

        int count = 1;
        while(!result.IsCompleted)
        {
            Console.Write($"Still waiting {count++}");
            Task.Delay(1000).Wait();
            Console.SetCursorPosition(0, Console.CursorTop);
        }
        Console.WriteLine();

        Console.WriteLine($"So {x}th fibonacci is {result.Result}");
    }

    static Task<BigInteger> Fibonacci(int x)
    {
        BigInteger a = 0;
        BigInteger b = 1;
        BigInteger c = a + b;

        for(int i = 3; i <= x; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return Task.FromResult(c);
    }

    static async Task<BigInteger> Calculate(int x)
    {
        var stopwatch = new Stopwatch();

        Console.WriteLine($"Starting to find Fibonacci...");
        
        stopwatch.Start();
        var result = await Task.Run(() => Fibonacci(x));
        stopwatch.Stop();

        Console.WriteLine($"Finished finding Fibonacci in {stopwatch.ElapsedMilliseconds}ms");

        return result;
    }
}