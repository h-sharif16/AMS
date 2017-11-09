using System;
using System.Globalization;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace AMS.Common.Biz
{
    public class CommonBiz
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNumeric(object Expression)
        {
            double retNum;

            var isNum = double.TryParse(Convert.ToString(Expression), NumberStyles.Any, NumberFormatInfo.InvariantInfo,
                out retNum);
            return isNum;
        }

        public static string GetSwcSH1(string value)
        {
            var algorithm = SHA1.Create();
            var data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            var sh1 = "";
            for (var i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }
            return sh1;
        }
    }
}