﻿using FinancialPortal.Accounts;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinancialPortal.DatabasePages
{
    /// <summary>
    /// Interakční logika pro UpdateAccount.xaml
    /// </summary>
    public partial class UpdateAccount : MetroWindow
    {
        //Database d = new Database();
        
        
        public UpdateAccount()
        {
            Account account = new Account();

            InitializeComponent();
            if (change.SelectedIndex == 1)
            {
                Controller control = new Controller();
                selectedUsersOption.Visibility = Visibility.Visible;
                textBoxStackPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                Controller control = new Controller();
                selectedUsersOption.Visibility = Visibility.Collapsed;
                textBoxStackPanel.Visibility=Visibility.Visible;
            }
            if (selectedOption.Text == "Remove")
            {
                
                Controller control = new Controller();
                //selectedUsers combobox recives list of avaliable accounts that it has
                control.availableAccounts();
                selectedUsers.ItemsSource = account.UserList;
            }
            if(selectedOption.Text == "Add")
            {
                Controller control = new Controller();
                
                //selectedUsers combobx recives list of all acounts except of the users that are included
                control.allAcounts();
                selectedUsers.ItemsSource = Controller.UserListObservable;
            }
        }

        

        private void UppdateAccount_click(object sender, RoutedEventArgs e)
        {
             
            choosingParametrs();
        }
        public void choosingParametrs()
        {
            Controller control = new Controller();
            if ((change.Text != "")&&(datagrid.SelectedIndex>-1)) { 
            if (change.Text =="Name")
            {
                    if(input.Text != null)
                    {
                        control.updateAccount("Name", input.Text, datagrid.SelectedIndex, 0, null);
                        this.Close();
                    }
               
            }
            if (change.Text == "User")
            {//remove user, add user
                    //remove is false and removes from list of accounts users
                    //add is true and adds from whole list of users
                    //if the user is there dont display him
                    if (selectedOption.Text != null && selectedUsers.Text != null)
                    {
                        if (selectedOption.Text == "Remove")
                        {
                            control.updateAccount("User", "", datagrid.SelectedIndex, selectedUsers.SelectedIndex, false);
                        }
                        if (selectedOption.Text == "Add")
                        {
                            control.updateAccount("User", "", datagrid.SelectedIndex, selectedUsers.SelectedIndex, true);
                        }
                        
                    }
                
                
                this.Close();
            }
            if (change.Text == "Type")
            {
                    if (input.Text != null)
                    {
                        control.updateAccount("Type", input.Text, datagrid.SelectedIndex, 0, null);

                        this.Close();
                    }
                        
            }
            if (change.Text == "MoneyStatus")
            {
                    if (input.Text != null)
                    {
                        control.updateAccount("MoneyStatus", input.Text, datagrid.SelectedIndex, 0, null);

                        this.Close();
                    }
                        
            }
            }
        }
    }
}
