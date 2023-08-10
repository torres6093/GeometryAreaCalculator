namespace GeometryAreaCalculator
{
    using GeometryAreaCalculator.Utils;

    /// <summary>
    /// Base abstract class for all geometric shapes.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// An abstract method for calculating the area of any 2D shape.
        /// </summary>
        protected abstract double GetArea();

        // !NB: Под "Вычисление площади фигуры без знания типа фигуры в compile-time" я понял, что пользователь, применяющий эту библиотеку
        // в своем проекте, не должен самостоятельно создавать экземпляр конкретного класса (new Polygon, new Triangle и тд),
        // поэтому создал несколько фабричных методов ниже. Таким образом, во время компиляции не будет известно, площадь для фигуры какого типа будет вычисляться.
        public static double GetAreaByCoordinates(List<(double, double)> points)
        {
            // Circle
            if (points.Count == 2)
            {
                var circle = new Circle(points[0], points[1]);
                return Math.Round(circle.GetArea(), Constants.decimalPlaces);
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

            return Math.Round(polygon.GetArea(), Constants.decimalPlaces);
        }

        public static double GetAreaByRadius(double radius)
        {
            var circe = new Circle(radius);
            return Math.Round(circe.GetArea(), Constants.decimalPlaces); ;
        }

        // !NB: Не уверен, можно ли вычислять площади других фигур, имея лишь длины сторон. Предположу, что нет, поэтому оставим здесь лишь треугольник
        // и в соответствующем классе обработаем исключение для некорректного кол-ва сторон.
        public static double GetAreaBySides(List<double> sides)
        {
            var triangle = new Triangle(sides);
            return Math.Round(triangle.GetArea(), Constants.decimalPlaces);
        }
    }
}
