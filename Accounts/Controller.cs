using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal.Accounts
{
    internal class Controller
    {
        ObservableCollection<Account> AccountListObservable { get; set; }
        ObservableCollection<User> UserListObservable { get; set; }

        public Controller()
        {
            AccountListObservable = new ObservableCollection<Account>();
            UserListObservable = new ObservableCollection<User>();
        }
        public void AddUser(User u)
        {
            UserListObservable.Add(u);
        }
        public void AddAccount(Account u)
        {
            AccountListObservable.Add(u);
        }


    }
}
