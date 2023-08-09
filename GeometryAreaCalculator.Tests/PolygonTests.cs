namespace GeometryAreaCalculator.Tests
{
    using NUnit.Framework;
    using GeometryAreaCalculator.Utils;

    [TestFixture]
    public class PolygonTests
    {
        [Test]
        public void CorrectCoordinatesTest()
        {
            var pentagon = new Polygon(new List<(double, double)> { (-4, 1), (1, 4), (2, 2), (5, 3), (1, -3) });

            Assert.AreEqual(pentagon.Area, 28, Constants.delta);
        }

        [Test]
        public void IncorrectCoordinatesTest()
        {
            Assert.That(() => new Polygon(new List<(double, double)> { (1.287, 7.13), (-2.44, 4.01) }),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("It's not a polygon. Add at least 3 points."));
        }
    }
}
