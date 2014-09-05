using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homsey.Core.Cache;
using Homsey.Core.Contract;
using Homsey.Core.Entities;
using Ninject;

namespace Homsey.Core
{
  public class Ninjecter
  {
    public void AddCoreInjections(IKernel kernel)
    {
      if (CacheConfiguration.IsEnabled)
      {
        kernel.Bind<IDataRepository>().To<DataRepository>().WhenInjectedInto<CacheManager>();
        kernel.Bind<IDataRepository>().To<CacheManager>().InSingletonScope();
      }

      else
      {
        kernel.Bind<IDataRepository>().To<DataRepository>();
      }
    }
  }
}
