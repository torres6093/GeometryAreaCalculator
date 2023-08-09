namespace GeometryAreaCalculator.Tests
{
    using GeometryAreaCalculator.Utils;
    using NUnit.Framework;

    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void CorrectRadiusTest()
        {
            var circle = new Circle(4.8254);

            Assert.AreEqual(circle.Area, 73.15037, Constants.delta);
        }

        [Test]
        public void NegativeRadiusTest()
        {
            Assert.That(() => new Circle(-14.3815),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Radius must be a positive number."));
        }

        [Test]
        public void MinDoubleRadiusTest()
        {
            // radius > 0
            Assert.DoesNotThrow(() => new Circle(Double.Epsilon));

            // radius is 0
            Assert.That(() => new Circle(Double.Epsilon / 2),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Radius must be a positive number."));
        }
    }
}
