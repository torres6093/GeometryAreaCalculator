namespace GeometryAreaCalculator
{
    using GeometryAreaCalculator.Utils;

    /// <summary>
    /// Class for working with a triangle shape.
    /// </summary>
    public class Triangle : Polygon
    {
        private readonly List<double> sides;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="sides">A list of triangle sides.</param>
        internal Triangle(List<double> sides) : base()
        {
            if (sides.Count != 3)
            {
                throw new ArgumentException("It's not a triangle. Use a collection with exactly 3 numbers.");
            }

            if (sides.Any(x => x <= 0))
            {
                throw new ArgumentException("It's not a triangle. Use only positive numbers.");
            }

            // !NB: Будем считать, что треугольник не может быть вырожден (поэтому неравенства нестрогие).
            if (sides[0] + sides[1] <= sides[2] || sides[0] + sides[2] <= sides[1] || sides[1] + sides[2] <= sides[0])
            {
                throw new ArgumentException("It's not a triangle. The triangle inequality is not correct.");
            }

            this.sides = sides.OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="points">A list of triangle vertex coordinates.</param>
        internal Triangle(List<(double, double)> points) : base(points)
        {
            // !NB: Будем считать, что треугольник не может быть вырожден (поэтому не станем проверять, что все 3 точки НЕ лежат на одной прямой).
        }

        /// <summary>
        /// Checks if a triangle is a right triangle.
        /// </summary>
        private bool HasRightAngle()
        {
            // !NB: О точности вычислений в задании указано не было, поэтому допустим некоторую погрешность.
            return Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) < Constants.delta;
        }

        /// <summary>
        /// Calculating the area of a triangle using Heron's formula.
        /// </summary>
        private double HeronFormulaArea()
        {
            double p = sides.Sum() / 2;
            return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
        }

        protected override double GetArea()
        {
            // !NB: Не было сказано, для чего необходима проверка на наличие прямого угла. Пусть используется для определения способа подсчета площади.
            return sides != null
                ? HasRightAngle()
                    ? sides[0] * sides[1] / 2
                    : HeronFormulaArea()
                : base.GetArea();
        }
    }
}
