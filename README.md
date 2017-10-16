# NConstraints
Adds additional [constraints](https://github.com/nunit/docs/wiki/Constraints) to [NUnit](https://github.com/nunit/nunit) such as comparing all the property values on two objects.

# Installing
You can find the latest stable NuGet package at [here](https://www.nuget.org/packages/SaturdayMP.NConstraints).  If you want the live on the wild side you can find the developer NuGet packages on [MyGet](https://www.myget.org/feed/saturdaymp/package/nuget/SaturdayMP.NConstraints).

If you have any issues with the installation please let me know by opening an [issue](https://github.com/saturdaymp/NConstraints/issues) or [pull request](https://github.com/saturdaymp/NConstraints/pulls).

# Quickstart
The additional constraints can be used when using [Assert.That](https://github.com/nunit/docs/wiki/Assertions) and extend the [Is helper class](https://github.com/nunit/nunit/blob/master/src/NUnitFramework/framework/Is.cs).  For example:

```C#
Assert.That(expected, SaturdayMP.NConstraints.Is.EquivalentPropertyWiseTo(actual);
```

If you don't want to prifix the additional constratins with the SaturdayMP.NConstraints namespace then add the following to the top your test file:

```C#
using NUnit.Framework; // Assume you already added this
using SaturdayMP.NConstraints;  // Add this statement.
using Is = SaturdayMP.NConstraints.Is; // Add this statement.
```

Now you can write:

```C#
Assert.That(expected, Is.EquivalentPropertyWiseTo(actual);
```

The complete file of this example looks like:

```C#
using NUnit.Framework;
using SaturdayMP.NConstraints;
using Is = SaturdayMP.NConstraints.Is;

namespace MyTestNamespace
{
  public class MyTests
  {
    [Test]
    public void PropertiesAreTheSame()
    {
      var expected = new TestClass() { IntegerProperty = 1 };
      var actual = new TestClass() {IntegerProperty = expected.IntegerProperty};

      Assert.That(expected, Is.EquivalentPropertyWiseTo(actual));
    }
  }
}
```

Notice that the using statement set the Is object. If you try:

```C#
using NUnit.Framework; 
using SaturdayMP.NConstraints;
```

You will get compile errors because there are two Is classes, one in the NUnit.Framework namespace and one in SaturdayMP.NConstraints.

Finally some code analyizers, like [ReSharper](https://www.jetbrains.com/resharper/), will raise warnings like "Access to a static member or a type via a dirvied type".  You can safely ignore these warnings, I don't know a good way to remove these warnings.  If you do please open an [issue](https://github.com/saturdaymp/NConstraints/issues) or [pull request](https://github.com/saturdaymp/NConstraints/pulls).

# Constraints
This project adds the following constraints to NUnit:

| Constraint Name | Description |
|---:             |---:         |
| [EquivalentPropertyWiseTo](#equivalentpropertywiseto) | Asserts that the property values of expected object are the same on the actual object. |

##  EquivalentPropertyWiseTo
Asserts that the property values of expected object are the same on the actual object.  The objects don't have to be the same class but if a property exists on the expected object but not on the actual object then the assert fails.

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

# Contributing 
If you have any questions, notice a bug, or have a suggestion/enhancment please let me know by opening a [issue](https://github.com/saturdaymp/NConstraints/issues).  Better yet create a [pull request](https://github.com/saturdaymp/NConstraints/pulls) with your fix.  Both are much appreciated.

# Acknowledgements
Thanks to the [NUnit team](https://github.com/orgs/nunit/people) for creating NUnit and continuing to support it.
