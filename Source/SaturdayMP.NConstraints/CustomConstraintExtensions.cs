using NUnit.Framework.Constraints;

namespace SaturdayMP.NConstraints
{
    /// <summary>
    ///     Make our custom constraints usual with NUnit <see cref="ConstraintExpression"/>.
    /// </summary>
    public static class CustomConstraintExtensions
    {
        /// <summary>
        ///     Make our custom <see cref="EquivalentPropertyWiseToConstraint"/> usable with the NUnit
        ///     <see cref="ConstraintExpression"/>.
        /// </summary>
        /// <param name="expression">The constraint expression to extend.</param>
        /// <param name="expected">The object with the expected object property values.</param>
        /// <returns>The <see cref="EquivalentPropertyWiseToConstraint"/> with the expected object set.</returns>
        public static EquivalentPropertyWiseToConstraint EquivalentPropertyWiseTo(this ConstraintExpression expression, object expected)
        {
            var constraint = new EquivalentPropertyWiseToConstraint(expected);
            expression.Append(constraint);

            return constraint;
        }
    }
}
