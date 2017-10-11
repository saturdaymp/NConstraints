# NConstraints
Custom constraints for NUnit.

# Installing
NuGet package coming soon.

# Quickstart
Coming soon.

##  EquivalentPropertyWise
Compares the values of all the properties of two objects.

```C#
/// <summary>
///     Properties don't match up.
/// </summary>
[Test]
public void PropertiesNotTheSame()
{
  var expected = new TestClass() {IntegerProperty = 1};
  var actual = new TestClass();

  Assert.That(expected, NUnit.Framework.Is.Not.EquivalentPropertyWiseTo(actual));
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
```
