namespace SaturdayMP.NConstraints
{
    /// <inheritdoc />
    /// <summary>
    ///     Custom constraint expression for testing properties of an object.
    /// </summary>
    /// <remarks>
    ///     You can write something like:
    ///     <code>
    ///         Assert.That(resultObject, Property.EquivalentTo(expectedObject));
    ///     </code>
    ///     Tried to override the <see cref="T:NUnit.Framework.Is" /> but resulted in too many name
    ///     conflicts and/or confusion.
    /// </remarks>
    public class Is : NUnit.Framework.Is
    {
        /// <summary>
        ///     Constraint to check that all the properties on the objects have the
        ///     same values.
        /// </summary>
        /// <param name="expected">The object with the expected property values.</param>
        /// <returns>The constraint with the expected object set.</returns>
        public static EquivalentPropertyWiseToConstraint EquivalentPropertyWiseTo(object expected)
        {
            return new EquivalentPropertyWiseToConstraint(expected);
        }
    }
}