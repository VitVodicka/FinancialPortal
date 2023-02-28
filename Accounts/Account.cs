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
    internal class Account : INotifyPropertyChanged
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

        
        public Account(string name, float deposit, int selectedIndex, string type)
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

        // This is a helper method to raise the PropertyChanged event
        // It is called whenever a property of the account changes
        public void change(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        // This method updates the name property of the account
        public void updateName(string name)
        {
            Name = name;
            change("Name");
        }

        // This method removes a user from the user list of the account
        public void removeUser(int index)
        {
            UserList.RemoveAt(index);
            change("UserList");
        }

        // This method updates the type property of the account
        public void updateType(string type)
        {
            Type = type;
            change("Type");
        }

        // This method updates the money status property of the account
        public void updateMoneyStatus(string moneyStatus)
        {
            MoneyStatus.Add(double.Parse(moneyStatus.Trim()));
            change("MoneyStatus");
        }

        // This method converts the user list of the account to a string
        // It is used to display the list of users in the UI
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
            UsersFromObservable = resault.Substring(0, resault.Length - 2);
            change("UsersFromObservable");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}


