using NUnit.Framework;
using NUnitHandson;

namespace NUnitHandson.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            calculator = null;
        }

        [TestCase(10, 20, 30)]
        [TestCase(5, 15, 20)]
        [TestCase(-5, 5, 0)]
        public void Add_TwoNumbers_ReturnsSum(int a, int b, int expected)
        {
            int actual = calculator.Add(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Ignore("Demo Ignore Attribute")]
        [Test]
        public void IgnoredTest()
        {
            Assert.Pass();
        }
    }
}