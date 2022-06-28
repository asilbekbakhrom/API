var tests = int.Parse(Console.ReadLine());

while(tests-- > 0)
{
    var coords = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    
    var prince = new Prince(
        End: new Point(coords[2], coords[3]),
        Start: new Point(coords[0], coords[1]));
    
    var numberOfPlanets = int.Parse(Console.ReadLine());

    var planets = new Circle[numberOfPlanets];

    for(int i = 0; i < numberOfPlanets; i++)
    {
        var planetCoords = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        planets[i] = new Circle(
            Center: new Point(planetCoords[0], planetCoords[1]), 
            Radius: planetCoords[2]);
    }

    Console.WriteLine($"Crosses {prince.CrossingCount(planets)} times!");
    
}