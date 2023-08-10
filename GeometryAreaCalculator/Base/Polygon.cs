namespace GeometryAreaCalculator
{
    /// <summary>
    /// Class for working with any N-vertices (N > 2) polygon.
    /// </summary>
    /// <remarks>
    /// !NB: Не совсем понятно, что имелось в виду под "Легкость добавления других фигур", поэтому добавил общий класс для любого многоугольника.
    /// В математику сильно не погружался, лишь вспомнил и нагуглил про формулу площади Гаусса.
    /// Поэтому, вроде как, несложно найти площадь для любого простого многоугольника, используя метод GetArea данного класса.
    /// P.S. Для "PI-образных" фигур предположим, что существует лишь круг, чтобы не углубляться в вышмат и интегралы.
    /// </remarks>
    public class Polygon : Shape
    {
        private readonly List<(double, double)>? coordinates;

        internal Polygon() {  }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon"/> class.
        /// </summary>
        /// <param name="points">A list of polygon vertex coordinates.</param>
        internal Polygon(List<(double, double)>? points)
        {
            if (points == null || points != null && points.Count < 3)
            {
                throw new ArgumentException("It's not a polygon. Add at least 3 points.");
            }

            coordinates = points;
        }

        protected override double GetArea()
        {
            double area = 0;

            for (int i = 0; i < coordinates?.Count; i++)
            {
                int j = (i + 1) % coordinates.Count;
                var a = coordinates[i];
                var b = coordinates[j];

                area += a.Item1 * b.Item2 - a.Item2 * b.Item1;
            }

            return Math.Abs(area) / 2;
        }
    }
}
