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
        
        public int Id { get; set; }
        

        public User(int id,string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;     
            
        }
        public override string ToString()
        {
            return Name + " "+ Surname;
        }

    }
}
