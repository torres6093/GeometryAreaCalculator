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
            Assert.AreEqual(
                Shape.GetAreaBySides(new List<double> { 6.451, 7.82456, 10.1 }),
                25.23727, Constants.delta);
        }

        [Test]
        public void NegativeSidesTest()
        {
            Assert.That(() => Shape.GetAreaBySides(new List<double> { 4.821, -3.1, 16.398 }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a triangle. Use only positive numbers."));
        }

        [Test]
        public void IncorrectSidesCountTest()
        {
            // Less (2<3)
            Assert.That(() => Shape.GetAreaBySides(new List<double> { 4.821, 16.398 }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a triangle. Use a collection with exactly 3 numbers."));

            // More (4>3)
            Assert.That(() => Shape.GetAreaBySides(new List<double> { 4.821, 16.398, 3.5, 8.12 }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a triangle. Use a collection with exactly 3 numbers."));
        }

        [Test]
        public void IncorrectTriangleInequalityTest()
        {
            Assert.That(() => Shape.GetAreaBySides(new List<double> { 4.821, 3.1, 16.398 }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a triangle. The triangle inequality is not correct."));
        }

        [Test]
        public void CorrectRightAngleTest()
        {
            Assert.AreEqual(Shape.GetAreaBySides(new List<double> { 3, 4, 5 }),
                6, Constants.delta);
        }

        [Test]
        public void CorrectCoordinatesTest()
        {
            Assert.AreEqual(Shape.GetAreaByCoordinates(new List<(double, double)> { (1.184, -5.6901), (11.3991, 24.173), (-3.182, 0.15) }),
                95.01975, Constants.delta);
        }
    }
}
