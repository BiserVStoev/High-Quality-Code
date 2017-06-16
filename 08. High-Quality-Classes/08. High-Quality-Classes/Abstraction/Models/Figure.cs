namespace Abstraction.Models
{
    using System;
    using Interfaces;

    public abstract class Figure : IFigure
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            string figureToString =
                $"I am a {this.GetType().Name}. My perimeter is {this.CalculatePerimeter():f2}." +
                $" My surface is {this.CalculateSurface():f2}";

            return figureToString;
        }

        protected void ValidateForNegativeOrZero(double value, string paramName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException($"{paramName}", $"{paramName} cannot be 0 or negative.");
            }
        }
    }
}
