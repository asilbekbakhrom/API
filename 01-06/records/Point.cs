public readonly record struct Point(int X, int Y)
{
    public double DistanceTo(Point b)
        => Math.Sqrt(Math.Pow(b.X - X, 2) + Math.Pow(b.Y - Y, 2));
}