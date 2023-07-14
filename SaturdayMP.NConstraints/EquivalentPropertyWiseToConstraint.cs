using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace SaturdayMP.NConstraints
{
    /// <inheritdoc />
    /// <summary>
    ///     Constraint to check that the property values on two objects are equal.
    /// </summary>
    public class EquivalentPropertyWiseToConstraint : Constraint
    {
        /// <inheritdoc />
        /// <summary>
        ///     Create a new constraint with the expected object set.
        /// </summary>
        /// <param name="expected">The object with the expected property values.</param>
        public EquivalentPropertyWiseToConstraint(object expected)
        {
            Expected = expected;
        }


        /// <inheritdoc />
        /// <remarks>
        ///     Overriden so supply custom message.
        /// </remarks>
        public override string Description { get; protected set; }

        /// <summary>
        ///     The expected object to match the properties on.
        /// </summary>
        public object Expected { get; }


        /// <inheritdoc />
        /// <remarks>
        ///     Checks that all the properties on the expected object
        ///     exist on the actual object and that the values are the same.
        ///     <para />
        /// 
        ///     If a property exists the expected object but not on the actual
        ///     object then this check failes. <para />
        /// 
        ///     When comparing the two property values it uses NUnit <see cref="EqualConstraint"/>
        /// </remarks>
        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            // Get all the properties for the expected object.
            var expectedProperties = Expected.GetType().GetRuntimeProperties();


            // Loop over each expected property and compare the
            // property of the same name in the actual object.
            foreach (var expectedProperty in expectedProperties)
            {
                // Does the property exist in the actual?  If not then
                // assert fails.
                var actualProperty = actual.GetType().GetRuntimeProperty(expectedProperty.Name);
                if (actualProperty == null)
                {
                    // Property does not exist.
                    Description = $"expected property {expectedProperty.Name} does not exist.";

                    return new ConstraintResult(this, actual, false);
                }


                // See if the two properties values are the same using the
                // existing NUnit EqualConstraint.
                var expectedValue = expectedProperty.GetValue(Expected, null);
                var actualValue = actualProperty.GetValue(actual, null);

                var equalConstraint = Has.Property(expectedProperty.Name).EqualTo(expectedValue);
                var equalConstraintResult = equalConstraint.ApplyTo(actualValue);

                if (!equalConstraintResult.IsSuccess)
                {
                    // The property values are not the same.  Let the user know what
                    // property does not match.
                    Description = $"property {expectedProperty.Name} value to be {expectedValue}";

                    return new ConstraintResult(this, equalConstraintResult.ActualValue, false);
                }
            }

            // All the properties are the same.
            return new ConstraintResult(this, actual, true);
        }
    }
}