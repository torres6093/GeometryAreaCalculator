namespace GeometryAreaCalculator.Tests
{
    using NUnit.Framework;
    using GeometryAreaCalculator.Utils;

    [TestFixture]
    public class PolygonTests
    {
        [Test]
        public void CorrectPolygonCoordinatesTest()
        {
            Assert.AreEqual(
                Shape.GetAreaByCoordinates(new List<(double, double)> { (-4, 1), (1, 4), (2, 2), (5, 3), (1, -3) }),
                28, Constants.delta);
        }

        [Test]
        public void IncorrectPolygonCoordinatesTest()
        {
            // Goes to Circle class
            Assert.DoesNotThrow(() => Shape.GetAreaByCoordinates(new List<(double, double)> { (1.287, 7.13), (-2.44, 4.01) }));
        }
    }
}
