namespace GeometryAreaCalculator
{
    using GeometryAreaCalculator.Utils;

    /// <summary>
    /// Base abstract class for all geometric shapes.
    /// </summary>
    public abstract class Shape
    {
        private readonly Lazy<double> area;

        private double Area => Math.Round(area.Value, Constants.decimalPlaces);

        protected Shape()
        {
            area = new Lazy<double>(GetArea);
        }

        /// <summary>
        /// An abstract method for calculating the area of any 2D shape.
        /// </summary>
        protected abstract double GetArea();

        public static double GetAreaByCoordinates(List<(double, double)> points)
        {
            // Circle
            if (points.Count == 2)
            {
                var circle = new Circle(points[0], points[1]);
                return circle.Area;
            }

            // Polygon
            Polygon polygon;

            switch (points.Count)
            {
                case 3:
                    polygon = new Triangle(points);
                    break;
                
                // !NB: Для таких N, что N-угольник может принимать конкретные фигуры (для N=4 это может быть квадрат, трапеция, параллелограмм...),
                // Можно создавать классы, внутри которых будет проверка, является ли N-угольник конкретной фигурой, и, в зависимости от этого,
                // алгоритмы вычисления площади могут быть различными.
                //
                //case 4:
                //    p = new Quadrangle(points);
                //    break;

                default:
                    polygon = new Polygon(points);
                    break;
            }

            return polygon.Area;
        }

        public static double GetAreaByRadius(double radius)
        {
            var circe = new Circle(radius);
            return circe.Area;
        }

        public static double GetAreaBySides(List<double> sides)
        {
            var triangle = new Triangle(sides);
            return triangle.Area;
        }
    }
}
