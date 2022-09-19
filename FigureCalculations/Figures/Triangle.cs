
namespace FigureCalculations.Figures
{
    public class Triangle : Shape
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;
        public override string? Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    SetName();
                }
                return _name;
            }
        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Side of a triangle cannot be less than or equal to zero");
            }
            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                throw new ArgumentOutOfRangeException("One side is greater than the sum of the others");
            }

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;            
        }

        public override double GetShapeArea()
        {
            double p = (_sideA + _sideB + _sideC) / 2;
            return Math.Sqrt(p * (p - _sideA) * (p - _sideB) * (p - _sideC));
        }

        private void SetName()
        {
            _name = String.Empty;

            double[] sides = { _sideA, _sideB, _sideC };
            Array.Sort(sides);
            if (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) < Math.Pow(sides[2], 2))
            {
                _name += "obtuse ";
            }
            if (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2))
            {
                _name += "rectangular ";
            }

            if (_sideA == _sideB && _sideA == _sideC)
            {
                _name += "equilateral ";
            }
            else if (_sideA == _sideB || _sideA == _sideC || _sideB == _sideC)
            {
                _name += "isosceles ";
            }
            else
            {
                _name += "versatile ";
            }

            _name += "triangle";
        }
    }
}
