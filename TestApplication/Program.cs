using FigureCalculations;
using FigureCalculations.Figures;

Shape circle = new Circle(5);
ShowArea(circle);

Shape triangle = new Triangle(3, 3, 5);
ShowArea(triangle);

void ShowArea(Shape shape)
{
    Console.WriteLine($"The area of the {shape.Name} is {shape.GetShapeArea()}");
}