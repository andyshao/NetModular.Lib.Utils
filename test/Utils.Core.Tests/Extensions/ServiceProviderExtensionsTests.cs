using Microsoft.Extensions.DependencyInjection;
using NetModular.Lib.Utils.Core.Attributes;
using Xunit;

namespace Utils.Core.Tests.Extensions
{
    public class ServiceProviderExtensionsTests : BaseTest
    {
        [Fact]
        public void GetStartWithTest()
        {
            var test = ServiceProvider.GetStartWith<ITest>("oldli");
            Assert.Equal("OLDLI", test.Test());
        }
    }

    public interface ITest
    {
        string Test();
    }

    [Singleton]
    public class OldliTest : ITest
    {
        public string Test()
        {
            return "OLDLI";
        }
    }

    [Singleton]
    public class LaoliTest : ITest
    {
        public string Test()
        {
            return "LAOLI";
        }
    }
}
