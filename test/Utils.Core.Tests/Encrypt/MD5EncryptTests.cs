using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Nmr.Lib.Utils.Core.Encrypt;
using Xunit;

namespace Utils.Core.Tests.Encrypt
{
    public class MD5EncryptTests : BaseTest
    {
        private readonly Md5Encrypt _encrypt;

        public MD5EncryptTests()
        {
            _encrypt = ServiceProvider.GetService<Md5Encrypt>();
        }

        [Fact]
        public void EncryptTest()
        {
            var str = _encrypt.Encrypt("iamoldli");

            Assert.Equal("5108C4039CD470FD89B626E03EC0ABEE", str);
        }
    }
}
