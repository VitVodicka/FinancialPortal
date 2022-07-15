using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class Mortgage:INotifyPropertyChanged
    {
        
        public int MonthlyPayment { get; set; }
        public int Totalypaid { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Change(string change){
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(change));
            }
        }
        public void Calculate(int loanamount, int interestrate, int interval)
        {

        }
    }
}
