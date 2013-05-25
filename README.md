FakeInjectionAddin
==================

A [NUnit][nunit] addin that uses [FakeItEasy!][fake-it-easy] to inject fakes into test methods.


### How to ?
* Copy `FakeInjectionAddin.dll` and `FakeItEasy.dll` into `<NUnit-directory>/addins`.
* Create a custom attribute named `InjectFakes`.
* Apply this attribute to test methods that you want to be injected with fakes.


### Example

```c#
[AttributeUsage (AttributeTargets.Method)]
class InjectFakesAttribute : Attribute { }
```

```c#
[Test, InjectFakes]
public void Test (IMyInterface fake)
{
  // Use fake in test.
  A.CallTo (() => fake.Blub()).Returns ("hello");

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
