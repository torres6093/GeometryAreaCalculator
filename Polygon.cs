namespace GeometryAreaCalculator
{
    /// <summary>
    /// Class for working with a any N-vertices (N > 2) polygon.
    /// </summary>
    /// <remarks>
    /// !NB: Не совсем понятно, что имелось в виду под "Легкость добавления других фигур", поэтому добавил общий класс для любого многоугольника.
    /// В математику сильно не погружался, лишь вспомнил и нагуглил про формулу площади Гаусса.
    /// Поэтому, вроде как, несложно найти площадь для любого простого многоугольника, используя базовый метод данного класса.
    /// P.S. Для Math.PI-образных фигур не стал погружаться. Хотя можно было бы сделать аналогичный общий класс для круга и элипса
    /// (и при желании для более сложных волнистых фигур, вспоминая высшую математику).
    /// </remarks>
    public class Polygon : Shape
    {
        private readonly List<(double, double)>? coordinates;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon"/> class.
        /// </summary>
        /// <param name="points">A list of polygon vertex coordinates.</param>
        public Polygon(List<(double, double)>? points)
        {
            if (points == null || points != null && points.Count < 3)
            {
                throw new ArgumentException("It's not a polygon. Add at least 3 points");
            }

            coordinates = points;
        }

        protected override double GetArea()
        {
            try
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
            catch (OverflowException)
            {
                throw new OverflowException("The polygon is too big.");
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error: ", ex);
            }
        }
    }
}
