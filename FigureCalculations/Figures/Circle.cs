
namespace FigureCalculations.Figures
{
    public class Circle : Shape
    {
        private readonly double _radius;
        public override string? Name => _name;
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius can't be less than or equal to zero");
            }
            _name = "Circle";
            _radius = radius;
        }
        public override double GetShapeArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
    }
}
