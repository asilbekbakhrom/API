using delegates;

namespace delegatesl;

public class Program
{
    // public delegate TResult Func<T1, TResult>(T1 t1);

    public static void Main(string[] args)
    {
        Func<int, bool> juft = Juftmi;
        var juftlar = "12345"
            .Select(c => int.Parse(c.ToString()))
            .Where(juft);
    }

    public static bool Juftmi(int x)
        => x % 2 == 0;















    public static int Square(int x) => x * x;

    public static bool IsEven(int x) => x % 2 == 0;

    public static double Area(int radius) => Math.PI * 2 * Square(radius);

    public static double Max(double a, double b) => a > b ? a : b;

    // public delegate TResult Func<TResult, T>(T t1);
    // public delegate TResult Func<TResult, T1, T2>(T1 t1, T2 t2);

    // public delegate void Action<T1>(T1 t1);

    public static void ShowTime(DateTime time)
        => Console.WriteLine($"{time:dd MMM, yyyy}");
        

    public static void Main2(string[] args)
    {
        Func<int, int> something = Square;
        // Func<bool, int> anything = IsEven;
        // Func<double, int> area = Area;

        Console.WriteLine($"{something?.Invoke(40)}");
        // Console.WriteLine($"{anything?.Invoke(40)}");
        
        Func<double, double, double> max = Max;

        // var sonlar = "12345".Select((c, index) 
        //     =>
        //     {
        //         return index % 2 switch
        //         {
        //             0 => int.Parse(c.ToString()),
        //             _ => -1
        //         };
        //     });

        var sonlar = "12345".Select(DigitOrZero);

        Console.WriteLine($"{max?.Invoke(12.2121, 12313.123123)}");

        Action<DateTime> show = ShowTime;
        show?.Invoke(DateTime.Now);

        "123456".ToList().ForEach(Console.WriteLine);
    }

    public static int DigitOrZero(char c, int index)
        => index % 2 switch
        {
            0 => int.Parse(c.ToString()),
            _ => -1
        };














    public static void Greet(string name)
        => Console.WriteLine($"Hello {name}");

    public delegate void Greeter(string name);


    public delegate int PerformCalculation(int a, int b);

    public static void Main1(string[] args)
    {
       PerformCalculation add = (x, y) => x + y;
       add += (x, y) => x * y;
       add += (x, y) => x / y;
       add += (x, y) => x % y;
       add += (x, y) => x - y;

       Console.WriteLine($"{add(1,2)}");
    }

    private static void HandleDownloaded()
    {
        Console.WriteLine($"Youtube downloader finished");
    }
}
