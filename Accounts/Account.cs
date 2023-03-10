using FinancialPortal.Accounts;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class Account : INotifyPropertyChanged
    {
        
        public string Name { get; set; }
        public int Index = -1;
        public string UsersFromObservable { get; set; }
        public ChartValues<double> MoneyStatus { get; set; }
        public double Money { get; set; }
        public int UserId { get; set; }

        public Account()
        {
            MoneyStatus = new ChartValues<double>();
           
        }

        
        public Account(string name, float deposit, int selectedIndex)
        {
            MoneyStatus = new ChartValues<double>();
            
            
            Index += 1;
            Name = name;
            if (MoneyStatus.Count == 0)
            {
                MoneyStatus.Add(0);
                MoneyStatus.Add(deposit);
            }
            else
            {
                MoneyStatus.Add(deposit);
            }
            
           
            
            Money = MoneyStatus.Last();
            UserId = selectedIndex;
            
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
        public void updateUser( int selectedUser)
        {
            UserId = selectedUser;
            fromCollectionToString();
            
        }



        // This method converts the user list of the account to a string
        // It is used to display the list of users in the UI
        public void fromCollectionToString()
        {
            try { 
            string resault = "";
            for (int i = 0; i < Controller.UserListObservable.Count; i++)
            {
                
                    if (i == UserId)
                    {
                        resault += Controller.UserListObservable[i].Name + " " + Controller.UserListObservable[i].Surname + ", ";
                    }
                
            }
            UsersFromObservable = resault.Substring(0, resault.Length - 2);
            change("UsersFromObservable");
            }
            catch(Exception ex)
            {
                Console.WriteLine("FromCollectionToString:"+ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}


