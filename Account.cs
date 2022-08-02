using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class Account:INotifyPropertyChanged
    {
        public double MoneyStatus { get; set; }
        public string Name { get; set; }

        public ObservableCollection<double> TransferHistory { get; set; }
        public Account()
        {
            TransferHistory = new ObservableCollection<double>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
