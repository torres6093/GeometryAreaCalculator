namespace GeometryAreaCalculator
{
    /// <summary>
    /// Class for working with a circle.
    /// </summary>
    public class Circle : Shape
    {
        private readonly double radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Radius of a given circle.</param>
        internal Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be a positive number.");
            }

            this.radius = radius;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <remarks>
        /// !NB: Альтернативный вариант, раз уж библиотека "поддерживает" работу с координатами.
        /// </remarks>
        /// <param name="center">Circle center coordinate.</param>
        /// <param name="endpoint">Any point on the circle.</param>
        internal Circle((double, double) center, (double, double) endpoint)
        {
            var xLength = Math.Abs(center.Item1 - endpoint.Item1);
            var yLength = Math.Abs(center.Item2 - endpoint.Item2);

            if (xLength == 0 || yLength == 0)
            {
                throw new ArgumentException("The same point recieved.");
            }

            this.radius = Math.Sqrt(xLength * xLength + yLength * yLength);
        }

        protected override double GetArea()
        {
            return Math.PI * radius * radius;
        }
    }
}