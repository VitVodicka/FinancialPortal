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
        public int Index { get; set; }
        public ObservableCollection<double> MoneyStatus { get; set; }
        public ObservableCollection<int> UserList { get; set; }
        
        public Account(string name, float deposit, int selectedIndex,string type  )
        {
            MoneyStatus = new ObservableCollection<double>();
            UserList = new ObservableCollection<int>();
            Index += 1;
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
        public void updateName(string name)
        {
            Name = name;
            Change("Name");
        }
        
        public void RemoveUser(int index)
        {
            UserList.RemoveAt(index);
            Change("UserList");
        }
        public void updateType(string type)
        {
            Type = type;
            Change("Type");
        }
        public void updateMoneyStatus(string moneyStatus)
        {
            MoneyStatus.Add(double.Parse(moneyStatus.Trim()));
            Change("MoneyStatus");
           
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
