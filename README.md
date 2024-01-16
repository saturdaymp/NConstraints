[![GitHub release (with filter)](https://img.shields.io/github/v/release/saturdaymp/NConstraints?sort=semver&label=Latest%20Release&labelColor=3C444C&logoColor=959DA5&logo=GitHub)](https://github.com/saturdaymp/XPlugins.iOS.BEMCheckBox/releases/latest)
[![Nuget](https://img.shields.io/nuget/dt/SaturdayMP.NConstraints?logo=nuget&label=Downloads&labelColor=3C444C&logoColor=959DA5)](https://www.nuget.org/packages/SaturdayMP.NConstraints)
![CI/CD](https://github.com/saturdaymp/NConstraints/actions/workflows/ci.yml/badge.svg)
![Release Notes](https://github.com/saturdaymp/NConstraints/actions/workflows/release-notes.yml/badge.svg)
[![GitHub Sponsors](https://img.shields.io/github/sponsors/saturdaymp?label=Sponsors&logo=githubsponsors&labelColor=3C444C)](https://github.com/sponsors/saturdaymp)

# NConstraints
Adds additional [constraints](https://github.com/nunit/docs/wiki/Constraints) to [NUnit](https://github.com/nunit/nunit) such as comparing the properties of two objects.

## Installing
Install by adding the [SaturdayMP.NContraints](https://www.nuget.org/packages/SaturdayMP.NConstraints) NuGet package:

```
dotnet add package SaturdayMP.NConstraints
```

You can find alternative install methods on the NuGet [page](https://www.nuget.org/packages/SaturdayMP.NConstraints).  

NConstraints is compatible with [.NET Standard 2.0](https://dotnet.microsoft.com/en-us/platform/dotnet-standard#versions) and [NUnit 3](https://github.com/nunit/nunit).  If you would like to use NConstraints on a older project please try [v1.0.0](https://www.nuget.org/packages/SaturdayMP.NConstraints/1.0.0) which is compatiable with [.NET Standard 1.6](https://dotnet.microsoft.com/en-us/platform/dotnet-standard#versions).

If you want the live on the wild side you can find the alpha/beta NuGet packages on [MyGet](https://www.myget.org/feed/saturdaymp/package/nuget/SaturdayMP.NConstraints).

Please report issues with the installation by opening an [issue](https://github.com/saturdaymp/NConstraints/issues) or [pull request](https://github.com/saturdaymp/NConstraints/pulls).  Feel free to ping me if you want to use NConstraints with an older versions of NUnit and/or .NET and I'll see what I can do.

## Quickstart
```C#
using NUnit.Framework; // Assume you already added this
using SaturdayMP.NConstraints;  // Add this statement.
using Is = SaturdayMP.NConstraints.Is; // Add this statement.
```

Now you can write:

```C#
Assert.That(expected, Is.EquivalentPropertyWiseTo(actual);
```

## Details
NConstratins extends the [Is helper class](https://github.com/nunit/nunit/blob/master/src/NUnitFramework/framework/Is.cs) which is used when writting [Assert.That](https://github.com/nunit/docs/wiki/Assertions) statements.  For example:

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
  [TestFixture]
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

## Constraints
This project adds the following constraints to NUnit:

| Constraint Name | Description |
|:---             |:---         |
| [EquivalentPropertyWiseTo](#equivalentpropertywiseto) | Asserts that the property values of expected object are the same on the actual object. |

###  EquivalentPropertyWiseTo
Asserts that the property values of expected object are the same on the actual object.  The objects don't have to be the same class but if a property exists on the expected object but not on the actual object then the assert fails.

```C#
/// <summary>
///     Objects are equivalent if they have the same properties and they are all the same.
/// </summary>
[Test]
public void PropertiesTheSame()
{
    var expected = new TestClass() {IntegerPropery = 1, StringPropery = "Test"};
    var actual = new TestClass() {IntegerPropery = expected.IntegerPropery, StringPropery = expected.StringPropery};

    Assert.That(expected, Is.EquivalentPropertyWiseTo(actual));
}

/// <summary>
///     Objects are alos equivalent if all the property values match but actual has properties not on actual.
/// </summary>
[Test]
public void PropertiesTheSame()
{
    var expected = new TestClass() {IntegerPropery = 1, StringPropery = "Test"};
    var actual = new TestClass2() {IntegerPropery = expected.IntegerPropery, SecondIntegerProperty = 2, StringPropery = expected.StringPropery};

    Assert.That(expected, Is.EquivalentPropertyWiseTo(actual));
}

/// <summary>
///     Objects are NOT equivalent if expected has a property not on actual.
/// </summary>
[Test]
public void PropertyDoesNotExistOnActual()
{
    var expected = new TestClass2() { IntegerPropery = 1, SecondIntegerProperty = 2, StringPropery = "Test"};
    var actual = new TestClass() { IntegerPropery = expected.IntegerPropery, StringPropery = expected.StringPropery};

    Assert.That(expected, Is.Not.EquivalentPropertyWiseTo(actual))
}
```

## Contributing 
If you have any questions, notice a bug, or have a suggestion/enhancment please let me know by:

- opening a [issue](https://github.com/saturdaymp/NConstraints/issues) or [pull request](https://github.com/saturdaymp/NConstraints/pulls).
- asking a question on [StackOverflow](https://stackoverflow.com/) with the tag *nconstraints*.
- send an e-mail to support@saturdaymp.com.

## Acknowledgements
Thanks to the [NUnit team](https://github.com/orgs/nunit/people) for creating NUnit and continuing to support it.  NUnit was one of the first frameworks as a young developer.
