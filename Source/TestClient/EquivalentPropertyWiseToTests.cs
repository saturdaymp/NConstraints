using NUnit.Framework;
using SaturdayMP.NConstraints;
using Is = SaturdayMP.NConstraints.Is;

namespace TestClient
{
    /// <summary>
    ///     Tests how an actual a developer would use the
    ///     <see cref="SaturdayMP.NConstraints.Is.EquivalentPropertyWiseTo"/> method when
    ///     writing tests.
    /// </summary>
    [TestFixture]
    public class EquivalentPropertyWiseToTests
    {
        /// <summary>
        ///     Properties don't match up.
        /// </summary>
        [Test]
        public void PropertiesNotTheSame()
        {
            var expected = new TestClass() {IntegerProperty = 1};
            var actual = new TestClass();

            Assert.That(expected, Is.Not.EquivalentPropertyWiseTo(actual));
        }

        /// <summary>
        ///     Properties match.
        /// </summary>
        [Test]
        public void PropertiesTheSame()
        {
            var expected = new TestClass() { IntegerProperty = 1 };
            var actual = new TestClass() {IntegerProperty = expected.IntegerProperty};

            Assert.That(expected, Is.EquivalentPropertyWiseTo(actual));
        }
    }
}
