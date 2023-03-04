using FinancialPortal.Accounts;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
            
            

            InitializeComponent();
            



        }
        private void change_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (change.SelectedIndex == 0)
            {
                Controller control = new Controller();
                selectedOption.Visibility = Visibility.Hidden;
                input.Visibility = Visibility.Visible;
                selectedUsers.Visibility = Visibility.Hidden;
            }
            else if (change.SelectedIndex == 1)
            {
                if ((selectedOption.SelectedIndex == 0) || (selectedOption.SelectedIndex == 1))
                {
                    Controller control = new Controller();
                    selectedOption.Visibility = Visibility.Visible;
                    
                    input.Visibility = Visibility.Hidden;
                    Account account = new Account();
                    selectedUsers.Visibility = Visibility.Visible;
                }
                else
                {
                    Controller control = new Controller();
                    selectedOption.Visibility = Visibility.Visible;
                    selectedUsers.Visibility = Visibility.Hidden;
                    input.Visibility = Visibility.Hidden;
                    Account account = new Account();
                }
                
                

            }
            else if (change.SelectedIndex == 2)
            {
                Controller control = new Controller();
                selectedOption.Visibility = Visibility.Hidden;
                input.Visibility = Visibility.Visible;
                selectedUsers.Visibility = Visibility.Hidden;
            }

        }
        private void removeADDSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedOption.SelectedIndex == 0)
            {
                Account account= new Account();
                Controller control = new Controller();
                //selectedUsers combobox recives list of avaliable accounts that it has
                control.availableAccounts();
                selectedUsers.Visibility = Visibility.Visible;
                selectedUsers.ItemsSource = account.UserList;
            }
            if (selectedOption.SelectedIndex == 1)
            {
                Controller control = new Controller();
                //selectedUsers combobx recives list of all acounts except of the users that are included
                control.allAcounts();
                selectedUsers.ItemsSource = Controller.UserListObservable;
                selectedUsers.Visibility = Visibility.Visible;
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
