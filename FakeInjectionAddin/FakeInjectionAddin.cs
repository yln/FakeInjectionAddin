using System;
using NUnit.Core.Extensibility;

namespace FakeInjectionAddin
{
  [NUnitAddin (Name = "FakeInjectionAddin", Description = "Uses FakeItEasy! to inject fakes into test methods.")]
  public class FakeInjectionAddin : IAddin
  {
    public bool Install (IExtensionHost host)
    {
      var testDecorators = host.GetExtensionPoint ("TestDecorators");
      testDecorators.Install (new InjectingTestDecorator());

      return true;
    }
  }
}