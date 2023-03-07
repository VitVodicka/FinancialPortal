using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal.Accounts
{
    internal class Controller : INotifyPropertyChanged
    {
        // The list of accounts that are observable by the UI
        public static ObservableCollection<Account> AccountListObservable { get; set; }
        // The list of users that are observable by the UI
        public static ObservableCollection<User> UserListObservable { get; set; }
        // The maximum index number for a user
        private static int max = -1;

        
        static Controller()
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

        // Method to add a user to the UserListObservable
        public void addUser(User u)
        {
            UserListObservable.Add(u);
            change("UserListObservable");
        }

        // Method to add an account to the AccountListObservable
        public static void addAccount(Account u)
        {
            AccountListObservable.Add(u);
        }
        
        // Method to update an account based on a given parameter, input, selectedIndex, selectedUser, and removeOrAdd flag
        public void updateAccount(string parameter, string input, int selectedIndex, int selectedUser)
        {
            try
            {
                foreach (Account account in AccountListObservable)
                {
                    if (account.Index == selectedIndex)
                    {
                        switch (parameter)
                        {
                            // If the parameter is Name, update the account name
                            case "Name":
                                account.updateName(input);
                                break;
                            // If the parameter is User, add or remove the selected user
                            case "User":                               
                                        account.updateUser(selectedUser);
                                break;
                           
                            // If the parameter is MoneyStatus, update the account money status
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Method to update a user based on the given id, valueToChange, and content
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

        // Method to get the maximum index number for a user
        public static int maxIndexUserList()
        {
            max++;
            /* don t know what was it for
            foreach(User u in UserListObservable)
            {
                if(u.Id > max)
                {
                    max = u.Id;
                }
            }*/
            return max;
        }
        // This method updates the user list of an account at a specified index
        // by adding a new user to the list.
        public void updateAddUser(int index, int selectedIndex)
        {
            try
            {
                foreach (Account account in AccountListObservable)
                {

                    if (account.Index == selectedIndex)
                    {
                        
                        account.UserId=index;
                        change("UserId");
                        
                        
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void availableAccounts()
        {

        }
        public void allAcounts()
        {

        }

        


    }
}
