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
        // Declare private static variables for email and password
        private static string settedEmail = "";
        private static string settedPassword = "ahoj";

        // Declare public property to get and set input password
        public static string InputPassword { get; set; }

        // Method to set the email address
        public void setEmail(string mail)
        {
            settedEmail = mail;
        }

        // Method to set the password
        public void setPassword(string password)
        {
            settedPassword = password;
        }

        // Method to get the value of password and compare it with input password
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