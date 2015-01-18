using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace WebApplication2.Helpers
{
    public class LoginHelper
    {

        public static string EncodeAsSHA1(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var enc = new System.Text.ASCIIEncoding();
            var com = enc.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(com)).ToLower().Replace("-", "");
        }
    }
}