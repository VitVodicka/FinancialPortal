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
        private string Name { get; set; }
        private string Type { get; set; }
        public ObservableCollection<float> MoneyStatus { get; set; }
        public ObservableCollection<int> UserList { get; set; }
        
        public Account(string name, float deposit, int selectedIndex,string type  )
        {
            MoneyStatus = new ObservableCollection<float>();
            UserList = new ObservableCollection<int>();
            
            Name = name;
            Type = type;
            MoneyStatus.Add(deposit);
            UserList.Add(selectedIndex);
            Change("MoneyStatus");
            Change("UserList");

        }
        public void Change(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
