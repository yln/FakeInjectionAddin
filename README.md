FakeInjectionAddin
==================

A [NUnit][nunit] addin that uses [FakeItEasy!][fake-it-easy] to inject fakes into test methods.


### Setup

Copy `FakeInjectionAddin.dll` and `FakeItEasy.dll` into `<NUnit-directory>/addins`.


### Example

```c#
[Test]
public void Test (IFoo foo)
{
  // Use fake in test.
  A.CallTo (() => foo.Bar()).Returns ("baz");

  // ...
}
```


### Require Addin (optional)

You may use the `RequiredAddin` attribute to signal test runners that the addin is required to run your tests.
This step is optional but may be helpful to avoid confusion.

```c#
[assembly: NUnit.Framework.RequiredAddin("FakeInjectionAddin")]
```

[nunit]:        http://www.nunit.org
[fake-it-easy]: https://github.com/FakeItEasy/FakeItEasy
