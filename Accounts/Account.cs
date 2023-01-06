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
        private string Name { get; set; }
        private string Type { get; set; }
        public int Index { get; set; }
        public string UsersFromObservable { get; set; }
        public ObservableCollection<double> MoneyStatus { get; set; }
        public ObservableCollection<int> UserList { get; set; }
        public ObservableCollection<int> AllUsersExceptAccount { get; set; }
        public Account()
        {
            MoneyStatus = new ObservableCollection<double>();
            UserList = new ObservableCollection<int>();
            AllUsersExceptAccount = new ObservableCollection<int>();
            CalculateUser();
            fromCollectionToString();

        }
        
        public Account(string name, float deposit, int selectedIndex,string type  )
        {
            MoneyStatus = new ObservableCollection<double>();
            UserList = new ObservableCollection<int>();
            AllUsersExceptAccount = new ObservableCollection<int>();
            CalculateUser();
            fromCollectionToString();
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
        public void CalculateUser()
        {
            foreach(User u in Controller.UserListObservable)
            {
                foreach(int userListIndex in UserList)
                {
                    if (u.Id != userListIndex)
                    {
                        AllUsersExceptAccount.Add(u.Id);
                        Change("AllUsersExceptAccount");
                    }
                }
            }
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
        public void fromCollectionToString()
        {
            foreach(User u in Controller.UserListObservable)
            {
                foreach(int userListPosition in UserList)
                {
                    if (u.Id == userListPosition)
                    {
                        UsersFromObservable += u.Name+",";
                    }
                }
                
            }
            if((UsersFromObservable != null) && (UsersFromObservable[-1] == ','))
            {
                UsersFromObservable.Remove(UsersFromObservable.Length - 1);
            }
            Change("UsersFromObservable");
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
