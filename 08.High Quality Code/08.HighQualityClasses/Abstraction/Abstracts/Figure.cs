namespace Abstraction.Abstracts
{
    using Abstraction.Contracts;

    public abstract class Figure : IFigure
    {
        protected Figure()
        {
        }

        public abstract double CalcPerimeter();

        public abstract double CalcArea();

        public override string ToString()
        {
            return string.Format(
                "I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.", 
                this.GetType().Name.ToLower(),
                this.CalcPerimeter(), 
                this.CalcArea());
        }
    }
}
