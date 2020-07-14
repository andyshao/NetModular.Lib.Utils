using Microsoft.Extensions.DependencyInjection;
using Nmr.Lib.Utils.Core.Encrypt;
using Xunit;

namespace Utils.Core.Tests.Encrypt
{
    public class DesEncryptTests : BaseTest
    {
        private readonly DesEncrypt _desEncrypt;

        public DesEncryptTests()
        {
            _desEncrypt = ServiceProvider.GetService<DesEncrypt>();
        }

        [Fact]
        public void EncryptTest()
        {
            var str = _desEncrypt.Encrypt("iamoldli");

            Assert.Equal("ragX6YemJJae+0eFK/og1w==", str);
        }

        [Fact]
        public void Decrypt4HexTest()
        {
            var str = _desEncrypt.Encrypt4Hex("iamoldli", lowerCase: true);

            Assert.Equal("ada817e987a624969efb47852bfa20d7", str);
        }
    }
}
