using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class PasswordChecker
    {

        private string settedPassword = "ahoj";
        public static string InputPassword { get; set; }  
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