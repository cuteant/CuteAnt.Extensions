﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Microsoft.Extensions.DependencyInjection.Performance
{
  [Config(typeof(CoreConfig))]
  public class ActivatorBenchmark
  {
    private const int OperationsPerInvoke = 50000;

    private IServiceProvider _transientSp;
    private CtorInvoker<D> _ctorInvoker;

    [GlobalSetup]
    public void GlobalSetup()
    {
      var services = new ServiceCollection();
      services.AddTransient<D>();
      _transientSp = services.BuildServiceProvider();
      _ctorInvoker = typeof(D).MakeDelegateForCtor<D>();
    }

    [Benchmark(Baseline = true, OperationsPerInvoke = OperationsPerInvoke)]
    public void ActivatorCreateInstance()
    {
      for (int i = 0; i < OperationsPerInvoke; i++)
      {
        var d = (D)System.Activator.CreateInstance(typeof(D));
      }
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public void DITransient()
    {
      for (int i = 0; i < OperationsPerInvoke; i++)
      {
        var d = _transientSp.GetService<D>();
      }
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public void DIActivatorCache()
    {
      for (int i = 0; i < OperationsPerInvoke; i++)
      {
        var d = TypeActivatorCache.CreateInstance<D>(_transientSp, typeof(D));
      }
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public void CreateInstance()
    {
      for (int i = 0; i < OperationsPerInvoke; i++)
      {
        var d = typeof(D).CreateInstance<D>();
      }
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public void CreateInstance1()
    {
      for (int i = 0; i < OperationsPerInvoke; i++)
      {
        var d = _ctorInvoker(new object[] { });
      }
    }
  }
  class D { }
}
