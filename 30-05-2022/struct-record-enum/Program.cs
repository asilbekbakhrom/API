var a = new Point(5, 7);
var b = new Point();


Console.WriteLine($"A({a.X},{a.Y}) va B({b.X},{b.Y}) nuqatalar orasidagi masofa {a.DistanceTo(b):F2}");

var circle = new Circle(b, 8);
Console.WriteLine($"Circle {circle} cotains Point {a}? {circle.Contains(a)}");