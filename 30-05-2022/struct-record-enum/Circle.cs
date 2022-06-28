public readonly struct Circle
{
    public readonly Point Center { get; init; }
    
    public readonly int Radius { get; init; }

    public Circle(Point center, int radius)
    {
        Center = center;
        Radius = radius;
    }
    
    public readonly bool Contains(Point p)
    {
        return Center.DistanceTo(p) < Radius;
    }

    public override string ToString()
    {
        return $"Center:{Center}, Radius:{Radius}";
    }
}