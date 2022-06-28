public readonly struct Point
{
    public readonly int X { get; init; }
    
    public readonly int Y { get; init; }
    
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public readonly double DistanceTo(Point b)
    {
        return Math.Sqrt(Math.Pow(b.X - X, 2) + Math.Pow(b.Y - Y, 2));
    }

    public override string ToString()
    {
        return $"{X}, {Y}";
    }
}