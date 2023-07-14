using NUnit.Framework;

namespace SaturdayMP.NConstraints.Tests.EquivalentPropertyWiseToConstraintTests
{
    /// <summary>
    ///     Test that the constructor for <see cref="EquivalentPropertyWiseToConstraint"/>
    ///     works as expected.
    /// </summary>
    [TestFixture]
    internal class ConstructorTests
    {
        /// <summary>
        /// Make sure the expected value is set when the constructor is called.
        /// </summary>
        [Test]
        public void ShouldSetTheExpectedValue()
        {
            var expected = new object();
            var constraintToTest = new EquivalentPropertyWiseToConstraint(expected);

            Assert.That(constraintToTest.Expected, NUnit.Framework.Is.EqualTo(expected));
        }
    }
}
