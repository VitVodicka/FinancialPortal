using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal.Accounts
{
    internal class Controller:INotifyPropertyChanged
    {
        ObservableCollection<Account> AccountListObservable { get; set; }
        public ObservableCollection<User> UserListObservable { get; set; }

        public Controller()
        {
            AccountListObservable = new ObservableCollection<Account>();
            UserListObservable = new ObservableCollection<User>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Change(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public void AddUser(User u)
        {
            UserListObservable.Add(u);
            Change("UserListObservable");
        }
        public void AddAccount(Account u)
        {
            AccountListObservable.Add(u);
            Change("AccountListObservable");
        }
        public void UpdateUser(int id, string valueToChange, string content)
        {
            foreach (User u in UserListObservable)
            {
                if (u.Id == id)
                {
                    if (valueToChange == u.Name)
                    {
                        u.Name = content;
                    }
                    if (valueToChange == u.Surname)
                    {
                        u.Surname = content;
                    }
                }
            }
        }
        public int MaxIndexUserList()
        {
            int max = 0;
            foreach(User u in UserListObservable)
            {
                if(u.Id > max)
                {
                    max = u.Id;
                }
            }
            return max;
        }

        


    }
}
