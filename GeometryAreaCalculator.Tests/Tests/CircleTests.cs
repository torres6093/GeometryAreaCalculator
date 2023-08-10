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
            Assert.AreEqual(
                Shape.GetAreaByRadius(4.8254), 73.15037, Constants.delta);
        }

        [Test]
        public void NegativeRadiusTest()
        {
            Assert.That(() => Shape.GetAreaByRadius(-14.3815),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Radius must be a positive number."));
        }

        [Test]
        public void MinDoubleRadiusTest()
        {
            // radius > 0
            Assert.DoesNotThrow(() => Shape.GetAreaByRadius(double.Epsilon));

            // radius is 0
            Assert.That(() => Shape.GetAreaByRadius(double.Epsilon / 2),
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Radius must be a positive number."));
        }
    }
}
