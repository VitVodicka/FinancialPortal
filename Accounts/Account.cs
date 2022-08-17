using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class Account
    {
        public int IDAccount { get; set; }
        public string Name { get; set; }
        public ObservableCollection<float> MoneyStatus { get; set; }
        public int UserId { get; set; }
        public Account()
        {
            MoneyStatus = new ObservableCollection<float>();
        }

        
    }

}
