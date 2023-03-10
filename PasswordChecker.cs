using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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