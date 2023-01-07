using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class PasswordChecker
    {
        public PasswordChecker()
        {

        }
        string InputPassword { get; set; }
        public bool returnValueFromPassword(string password)
        {
            if (password == InputPassword)
            {
                return true;
            }
            return false;
        }
    }
}
