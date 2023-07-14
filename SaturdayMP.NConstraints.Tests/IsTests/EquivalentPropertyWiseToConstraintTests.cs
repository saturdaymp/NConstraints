using NUnit.Framework;

namespace SaturdayMP.NConstraints.Tests.IsTests
{
    /// <summary>
    ///     Check that the <see cref="Is.EquivalentPropertyWiseTo"/> works as expected.
    /// </summary>
    [TestFixture]
    public class EquivalentPropertyWiseToConstraintTests
    {
        /// <summary>
        ///     Make sure the expected object is set correctly.
        /// </summary>
        [Test]
        public void ShouldSetTheExpectedObject()
        {
            var expectedObject = new object();

            var actual = Is.EquivalentPropertyWiseTo(expectedObject);
            
            Assert.That(actual, NUnit.Framework.Is.Not.Null);
            Assert.That(actual.Expected, NUnit.Framework.Is.EqualTo(expectedObject));
        }
    }
}
