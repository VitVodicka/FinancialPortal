﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinancialPortal.Accounts
{
    internal class Controller : INotifyPropertyChanged
    {
        // The list of accounts that are observable by the UI
        public static ObservableCollection<Account> AccountListObservable { get; set; }
        // The list of users that are observable by the UI
        public static ObservableCollection<User> UserListObservable { get; set; }
        public static ObservableCollection<string> AccountNames { get; set; }
        // The maximum index number for a user
        private static int max = -1;

        
        static Controller()
        {
            AccountListObservable = new ObservableCollection<Account>();
            UserListObservable = new ObservableCollection<User>();
            AccountNames = new ObservableCollection<string>();
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
        //from observableCollections selct names and add it into its own collection
        public void NameFromObservable()
        {
            AccountNames.Clear();
            foreach(Account a in AccountListObservable)
            {
                AccountNames.Add(a.Name);
                change("AccountNames");
            }

      
        }
        
        // Method to update an account based on a given parameter, input, selectedIndex, selectedUser, and removeOrAdd flag
        public void updateAccount(string parameter, string input, int selectedIndex, int selectedUser)
        {
            
            try
            {
                //sends a sql update command to database
                new Database().UpdateAccount(parameter, input, Controller.AccountListObservable[selectedIndex].Index, Controller.UserListObservable[selectedUser].Id);
                for (int i = 0; i < Controller.AccountListObservable.Count; i++)
                {
                    //it goes through AccountListObservable and if the index of AccountListObservable equals to selectedIndex of AccountListObservable then it will change
                    if (Controller.AccountListObservable[i].Index== Controller.AccountListObservable[selectedIndex].Index)

                    switch (parameter)
                    {
                        // If the parameter is Name, update the account name
                        case "Name":
                            AccountListObservable[i].updateName(input);
                            AccountListObservable[i].fromCollectionToString();//converts users into string
                            NameFromObservable();//refreshes the name to the combobox
                            break;
                        // If the parameter is User, add or remove the selected user
                        case "User":
                            AccountListObservable[i].updateUser(Controller.UserListObservable[selectedUser].Id);//it will change Account at position i and it will change it to selectedUser ID from UserListObservable
                            AccountListObservable[i].fromCollectionToString();
                            NameFromObservable();//refreshes the names into combobox
                            break;

                            // If the parameter is MoneyStatus, update the account money status

                    }
                }
                    
                    
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in Controller.updateAccount"+e.Message);
            }
        }

        // Method to update a user based on the given id, valueToChange, and content
        public static void updateUser(int id, string valueToChange, string content)
        {
            try { 
            var user = Controller.UserListObservable[id];
                //updates user to database
                new Database().updateUser(valueToChange, content, user.Id);
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
            catch(Exception e) { MessageBox.Show("updateUser:"+e.Message); }
        }

        // Method to get the maximum index number for a user
        public static int maxIndexUserList()
        {
            max++;
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
                MessageBox.Show("updateAddUser:"+e.Message);
            }
        }


        


    }
}
