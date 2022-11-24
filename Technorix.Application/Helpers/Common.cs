using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technorix.Application.Helpers
{
    public class Common
    {
        private readonly IConfiguration _configuration;

        public Common(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    }

    public static class TypeConverterExtension
    {
        public static byte[] ToByteArray(this string value) =>
        Convert.FromBase64String(value);
    }
}
