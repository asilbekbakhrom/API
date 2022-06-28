public abstract class Shape
{
    public static double PI { get; set; }

    static Shape()
    {
        PI = 15;
    }

    public Shape()
    {
        PI = 13;
    }
    
    public abstract double GetSurface();
}