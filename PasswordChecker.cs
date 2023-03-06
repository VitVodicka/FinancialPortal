using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class PasswordChecker
    {
        private static string settedEmail = "";
        private static string settedPassword = "ahoj";
        public static string InputPassword { get; set; }  
        public void setEmail(string mail)
        {
            settedEmail= mail;
        }
        public void setPassword(string password) { 
            settedPassword= password;
        }
        public bool getValueFromPassword()
        {
            if (settedPassword == InputPassword)
            {
                return true;
            }
            return false;
        }
    }
}