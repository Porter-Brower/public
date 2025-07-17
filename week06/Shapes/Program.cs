using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
                                                   // those are my favorite colors 
        shapes.Add(new Square("Yellow", 3));
        shapes.Add(new Rectangle("baby Blue", 4, 5));
        shapes.Add(new Circle("military sand", 6));

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {Math.Round(area, 2)}.");
        }
    }
}
