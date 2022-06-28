using System.Diagnostics;

var ctokenSource = new CancellationTokenSource();
var ctoken = ctokenSource.Token;

Task.Run(async () =>
{
    var passed = await Pass(ctoken);
    Console.WriteLine($"Cancelled after {passed}ms.");

    return passed;
}, ctoken)
.ContinueWith(task =>
{
    task.Exception?.Handle(e => 
    {
        Console.WriteLine($"{e.Message}");

        return true;
    });

    Console.WriteLine($"You cancelled the task idiot.");
    
    
}, TaskContinuationOptions.OnlyOnCanceled);
// .ContinueWith<long>((task, t) => 
// {
//     Console.WriteLine($"Taks completed successfully {t}");

//     return 1;
// }, TaskContinuationOptions.OnlyOnRanToCompletion);

while(Console.ReadLine() != "cancel") { }

ctokenSource.Cancel();

Console.WriteLine($"Cancelled");
Console.ReadLine();

static async Task<long> Pass(CancellationToken ctoken)
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    await Task.Delay(3000, ctoken);

    if(ctoken.IsCancellationRequested)
    {
        throw new Exception("You cancelled the task!");
    }

    return stopwatch.ElapsedMilliseconds;
}