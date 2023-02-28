using FinancialPortal.Accounts;
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
        public string Name { get; set; }
        public string Type { get; set; }
        public int Index { get; set; }
        public string UsersFromObservable { get; set; }
        public ObservableCollection<double> MoneyStatus { get; set; }
        public ObservableCollection<int> UserList { get; set; }
        public Account()
        {
            MoneyStatus = new ObservableCollection<double>();
            UserList = new ObservableCollection<int>();
            
        }
        
        public Account(string name, float deposit, int selectedIndex,string type  )
        {
            MoneyStatus = new ObservableCollection<double>();
            UserList = new ObservableCollection<int>();
            
            Index += 1;
            Name = name;
            Type = type;
            MoneyStatus.Add(deposit);
            UserList.Add(selectedIndex);
            change("MoneyStatus");
            change("UserList");

        }
        public void change(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public void updateName(string name)
        {
            Name = name;
            change("Name");
        }
        
        public void removeUser(int index)
        {
            UserList.RemoveAt(index);
            change("UserList");
        }
        public void updateType(string type)
        {
            Type = type;
            change("Type");
        }
        public void updateMoneyStatus(string moneyStatus)
        {
            MoneyStatus.Add(double.Parse(moneyStatus.Trim()));
            change("MoneyStatus");
           
        }
        public void fromCollectionToString()
        {
            string resault = "";
            for (int i = 0; i < Controller.UserListObservable.Count; i++)
            {
                for (int k = 0; k < UserList.Count; k++)
                {
                    if (i == UserList[k])
                    {
                        resault += Controller.UserListObservable[i].Name + " " + Controller.UserListObservable[i].Surname + ", ";
                    }
                    
                }
                
                
            }
            UsersFromObservable=resault.Substring(0, resault.Length-2);
            change("UsersFromObservable");
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
