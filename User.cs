using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public Account Account { get; set; }

        public User(string name, string surname, double moneyStatus, Account account)
        {
            Name = name;
            Surname = surname;
            
            Account = account;
        }
    }
}
