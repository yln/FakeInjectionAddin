FakeInjectionAddin
==================

A NUnit addin that uses [FakeItEasy!][fake-it-easy] to inject fakes into test methods.


### How to ?
* Copy FakeInjectionAddin.dll and FakeItEasy.dll into <NUnit-directory>/addins.
* Create a custom attribute named 'InjectFakes'.
* Apply this attribute to your test methods that you want to be injected with fakes.


### Example

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

Use the RequiredAddin attribute to signal that the addin is required to run your tests.
This is optional but may be helpful to avoid confusion.

```c#
[assembly: NUnit.Framework.RequiredAddin("FakeInjectionAddin")]
```

[fake-it-easy]: https://github.com/FakeItEasy/FakeItEasy
