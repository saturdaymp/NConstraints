using NUnit.Framework;

namespace SaturdayMP.NConstraints.Tests.EquivalentPropertyWiseToConstraintTests
{
    /// <summary>
    ///     Tests that the apply to correctly figures out if the property
    ///     values between two objects are the same.
    /// </summary>
    [TestFixture]
    internal class ApplyToTests
    {
        /// <summary>
        ///     Test that the assert is raised if a property exists on the
        ///     the expected object but not the actual object.
        /// </summary>
        [Test]
        public void PropertyDoesNotExistOnActual()
        {
            var expected = new TestClass2() { IntegerPropery = 1, SecondIntegerProperty = 2, StringPropery = "Test"};
            var actual = new TestClass() { IntegerPropery = expected.IntegerPropery, StringPropery = expected.StringPropery};

            var constraintToTest = new EquivalentPropertyWiseToConstraint(expected);
            var result = constraintToTest.ApplyTo(actual);

            Assert.That(result, NUnit.Framework.Is.Not.Null);
            Assert.That(result.IsSuccess, NUnit.Framework.Is.False);
            Assert.That(result.Description, NUnit.Framework.Is.EqualTo("expected property SecondIntegerProperty does not exist."));
        }

        /// <summary>
        ///     Test that the assert passes if all the properties and
        ///     property values are the same that the constratint passes.
        /// </summary>
        [Test]
        public void PropertiesAreSame()
        {
            var expected = new TestClass() {IntegerPropery = 1, StringPropery = "Test"};
            var actual = new TestClass2() {IntegerPropery = expected.IntegerPropery, SecondIntegerProperty = 2, StringPropery = expected.StringPropery};

            var constraintToTest = new EquivalentPropertyWiseToConstraint(expected);
            var result = constraintToTest.ApplyTo(actual);

            Assert.That(result, NUnit.Framework.Is.Not.Null);
            Assert.That(result.IsSuccess, NUnit.Framework.Is.True);
            Assert.That(result.Description, NUnit.Framework.Is.Null);
        }

        /// <summary>
        ///     Make sure the constraint failes if the property
        ///     values are different.
        /// </summary>
        [Test]
        public void PropertiesAreDifferent()
        {
            var expected = new TestClass() { IntegerPropery = 1, StringPropery = "Test" };
            var actual = new TestClass2() { IntegerPropery = 999, SecondIntegerProperty = 2, StringPropery = expected.StringPropery };

            var constraintToTest = new EquivalentPropertyWiseToConstraint(expected);
            var result = constraintToTest.ApplyTo(actual);

            Assert.That(result, NUnit.Framework.Is.Not.Null);
            Assert.That(result.IsSuccess, NUnit.Framework.Is.False);
            Assert.That(result.Description, NUnit.Framework.Is.EqualTo("property IntegerPropery value to be 1"));
        }
    }
}
