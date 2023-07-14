namespace SaturdayMP.NConstraints.Tests.EquivalentPropertyWiseToConstraintTests
{
    /// <summary>
    ///     Class with some same properties and different ones
    ///     then <see cref="TestClass"/>.  For testing the <see cref="EquivalentPropertyWiseToConstraint"/>.
    /// </summary>
    internal class TestClass2
    {
        public int IntegerPropery { get; set; }

        public string StringPropery { get; set; }

        public int SecondIntegerProperty { get; set; }
    }
}
