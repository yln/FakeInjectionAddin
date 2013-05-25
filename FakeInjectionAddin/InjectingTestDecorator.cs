﻿using System;
using System.Linq;
using System.Reflection;
using FakeItEasy;
using NUnit.Core;
using NUnit.Core.Extensibility;

namespace FakeInjectionAddin
{
  public class InjectingTestDecorator : ITestDecorator
  {
    private static readonly FieldInfo s_argumentsField = typeof (TestMethod).GetField ("arguments", BindingFlags.NonPublic | BindingFlags.Instance);
    private static readonly MethodInfo s_createFakeMethod = typeof (A).GetMethod ("Fake", Type.EmptyTypes);

    public Test Decorate (Test test, MemberInfo member)
    {
      var testMethod = test as TestMethod;
      if (testMethod == null)
        return test;

      if (!ShouldInjectFakes (testMethod))
        return test;

      var parameters = testMethod.Method.GetParameters();
      var arguments = parameters.Select (CreateFake).ToArray();

      SetArguments (testMethod, arguments);
      test.RunState = RunState.Runnable;

      return test;
    }

    private bool ShouldInjectFakes (TestMethod testMethod)
    {
      // We only need to inject arguments if the test isn't already runnable.
      if (testMethod.RunState != RunState.NotRunnable)
        return false;

      var attributes = testMethod.Method.GetCustomAttributes (inherit: true);
      return attributes.Any (a => a.GetType().Name == "InjectFakes");
    }

    private object CreateFake (ParameterInfo parameter)
    {
      var fakeFactory = s_createFakeMethod.MakeGenericMethod (parameter.ParameterType);
      return fakeFactory.Invoke (null, null);
    }

    private void SetArguments (TestMethod testMethod, object[] arguments)
    {
      s_argumentsField.SetValue (testMethod, arguments);
    }
  }
}