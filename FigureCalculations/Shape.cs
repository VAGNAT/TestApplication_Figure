namespace FigureCalculations
{
    public abstract class Shape : IOperationShape
    {
        protected string? _name;
        public abstract string? Name {get;}
        public abstract double GetShapeArea();        
    }
}