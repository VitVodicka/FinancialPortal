using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class User
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        
        

        public User(int id,string name, string surname)
        {
            Name = name;
            Surname = surname;     
            
        }
    }
}
