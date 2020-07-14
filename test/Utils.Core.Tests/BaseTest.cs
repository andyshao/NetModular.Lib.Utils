using System;
using Microsoft.Extensions.DependencyInjection;
using NetModular.Lib.Utils.Core;

namespace Utils.Core.Tests
{
   public class BaseTest
   {
       protected readonly IServiceProvider ServiceProvider;

       public BaseTest()
       {
           var services=new ServiceCollection();
           services.AddUtilsServices();
           ServiceProvider = services.BuildServiceProvider();
       }
   }
}
