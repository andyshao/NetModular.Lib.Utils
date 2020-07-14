using Microsoft.Extensions.DependencyInjection;
using Nmr.Lib.Utils.Core.Helpers;
using Xunit;

namespace Utils.Core.Tests.Helpers
{
    public class VerifyCodeHelperTests : BaseTest
    {
        private readonly VerifyCodeHelper _helper;

        public VerifyCodeHelperTests()
        {
            _helper = ServiceProvider.GetService<VerifyCodeHelper>();
        }

        [Fact]
        public void GenerateString2Base64Test()
        {
            var base64 = _helper.GenerateString2Base64(out string code);

            Assert.Equal(6, code.Length);
        }
    }
}
