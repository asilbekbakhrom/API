public class Rectangle : Shape
{
    public Rectangle(int height, int width)
    {
        Height = height;
        Width = width;
    }

    public int Height { get; set; }
    public int Width { get; set; }

    
    public override double GetSurface()
    {
        return Width * Height;
    }
}