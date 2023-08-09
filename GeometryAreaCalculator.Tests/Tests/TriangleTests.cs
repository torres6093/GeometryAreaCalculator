namespace GeometryAreaCalculator.Tests
{
    using GeometryAreaCalculator.Utils;
    using NUnit.Framework;

    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void CorrectSidesTest()
        {
            var triangle = new Triangle(new List<double> { 6.451, 7.82456, 10.1 });

            Assert.AreEqual(triangle.Area, 25.23727, Constants.delta);
        }

        [Test]
        public void NegativeSidesTest()
        {
            Assert.That(() => new Triangle(new List<double> { 4.821, -3.1, 16.398 }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a triangle. Use only positive numbers."));
        }

        [Test]
        public void IncorrectSidesCountTest()
        {
            // Less
            Assert.That(() => new Triangle(new List<double> { 4.821, 16.398 }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a triangle. Use a collection with exactly 3 numbers."));

            // More
            Assert.That(() => new Triangle(new List<double> { 4.821, 16.398, 3.5, 8.12 }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a triangle. Use a collection with exactly 3 numbers."));
        }

        [Test]
        public void IncorrectTriangleInequalityTest()
        {
            Assert.That(() => new Triangle(new List<double> { 4.821, 3.1, 16.398 }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a triangle. The triangle inequality is not correct."));
        }

        [Test]
        public void CorrectRightAngleTest()
        {
            var triangle = new Triangle(new List<double> { 3, 4, 5 });

            Assert.AreEqual(triangle.Area, 6, Constants.delta);
            Assert.True(triangle.CalcLikeRightAngle);
        }

        [Test]
        public void CorrectCoordinatesTest()
        {
            var triangle = new Triangle(new List<(double, double)> { (1.184, -5.6901), (11.3991, 24.173), (-3.182, 0.15) });
            Assert.AreEqual(triangle.Area, 95.01975, Constants.delta);
        }

        [Test]
        public void IncorrectCoordinatesTest()
        {
            // Less
            Assert.That(() => new Triangle(new List<(double, double)> { (1.287, 7.13), (-2.44, 4.01) }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a polygon. Add at least 3 points."));

            // More
            Assert.That(() => new Triangle(new List<(double, double)> { (1.287, 7.13), (-2.44, 4.01), (7.87, 0.13), (-1.55, 14.23) }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a triangle. Use exactly 3 points."));
        }
    }
}
