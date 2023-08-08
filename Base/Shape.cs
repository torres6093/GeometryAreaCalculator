using GeometryAreaCalculator.Utils;

namespace GeometryAreaCalculator
{
    /// <summary>
    /// Base abstract class for all geometric shapes.
    /// </summary>
    public abstract class Shape
    {
        private readonly Lazy<double> area;

        public double Area => Math.Round(area.Value, Constants.decimalPlaces);

        protected Shape()
        {
            area = new Lazy<double>(GetArea);
        }

        /// <summary>
        /// An abstract method for calculating the area of any 2D shape.
        /// </summary>
        protected abstract double GetArea();
    }
}
