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
        public static ObservableCollection<Account> AccountListObservable { get; set; }
        public  static ObservableCollection<User> UserListObservable { get; set; }
        
        

        public Controller()
        {
            AccountListObservable = new ObservableCollection<Account>();
            UserListObservable = new ObservableCollection<User>();
            
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void change(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public void addUser(User u)
        {
            UserListObservable.Add(u);
            change("UserListObservable");
        }
        public static void addAccount(Account u)
        {
            AccountListObservable.Add(u);
            
        }
        public void updateAccount(string parameter,string input,int selectedIndex,int selectedUser, bool? removeOrAdd)
        {
            try
            {
                foreach (Account account in AccountListObservable)
                {

                    if (account.Index == selectedIndex)
                    {
                        switch (parameter)
                        {
                            case "Name":
                                account.updateName(input);
                                break;
                            case "User":
                                if (removeOrAdd == false)
                                {
                                    account.RemoveUser(selectedIndex);
                                    
                                }
                                if(removeOrAdd == true)
                                {
                                    updateAddUser(selectedIndex,selectedIndex);
                                }
                                
                                break;
                            case "Type":
                                account.updateType(input);
                                break;
                            case "MoneyStatus":
                                account.updateMoneyStatus(input);
                                break;





                        }
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }
        public static void updateUser(int id, string valueToChange, string content)
        {
            var user = Controller.UserListObservable[id];
            if (valueToChange == "Name")
            {
                user.Name = content;
            }
            else if (valueToChange == "Surname")
            {
                user.Surname = content;
            }
            Controller.UserListObservable[id] = user;
        }
        public int maxIndexUserList()
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
        public void updateAddUser(int index, int selectedIndex)
        {
            try
            {
                foreach (Account account in AccountListObservable)
                {

                    if (account.Index == selectedIndex)
                    {
                        
                        account.UserList.Add(index);
                        change("UserList");
                        
                        
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void avaiableAccounts()
        {

        }
        public void allAcounts()
        {

        }

        


    }
}
