public class Circle : Shape
{
    public int Radius { get; set; }
    
    public Circle(int radius)
    {
        Radius = radius;
    }
    
    public override double GetSurface()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}