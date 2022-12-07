using System.Text.RegularExpressions;
using System;

namespace CompupharmLtd.Service
{
    public static class UtilityService
    {
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPhoneNbr(string number)
        {
            string motif = @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$";

            if (number != null) return Regex.IsMatch(number, motif);
            else return false;
        }
    }
}
