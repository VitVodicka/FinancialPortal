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
        public void setPassword(string password)
        {
            InputPassword=password;
        }
        private string InputPassword { get; set; }
        public bool getValueFromPassword(string password)
        {
            if (password == InputPassword)
            {
                return true;
            }
            return false;
        }
    }
}
