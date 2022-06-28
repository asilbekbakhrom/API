var son = int.Parse(Console.ReadLine());

var result = son switch
{
    > 0 => "Positive",
    not > 0 and not 0 => "Negative",
    _ => "Zero"
};

Console.WriteLine(result);



var today = DateTime.Now;

if(today is { Day: 28, Month: 2 })
{
    Console.WriteLine("Happy Birthday 🥳");
}