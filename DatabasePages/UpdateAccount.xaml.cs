using FinancialPortal.Accounts;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
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
                input.Visibility = Visibility.Visible;
                selectedUsers.Visibility = Visibility.Hidden;
            }
            if (change.SelectedIndex == 1)
            {
                input.Visibility = Visibility.Hidden;

                selectedUsers.Visibility = Visibility.Visible;
               
            }
            

        }
        


        private void UppdateAccount_click(object sender, RoutedEventArgs e)
        {
             
            choosingParametrs();
        }
        public void choosingParametrs()
        {
            try { 
            Controller control = new Controller();
            if ((change.Text != "")&&(datagrid.SelectedIndex>-1)) { 
            if (change.Text =="Name")
            {
                    if(input.Text != "")
                    {
                        control.updateAccount("Name", input.Text, datagrid.SelectedIndex, 0);
                        this.Close();
                    }
               
            }
            if (change.Text == "User")
            {//remove user, add user
                    //remove is false and removes from list of accounts users
                    //add is true and adds from whole list of users
                    //if the user is there dont display him
                    if ( selectedUsers.Text != "")
                    {
                        
                        control.updateAccount("User", "", datagrid.SelectedIndex, selectedUsers.SelectedIndex);
                        this.Close();
                        
                    }
                
                
                this.Close();
            }
          
            if (change.Text == "MoneyStatus")
            {
                    if (input.Text != "")
                    {
                        control.updateAccount("MoneyStatus", input.Text, datagrid.SelectedIndex, 0);

                        this.Close();
                    }
                        
            }
            }
            else
            {
                MessageBox.Show("Not changed value or not selcted value to change");
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Choosing parametrs"+ex.Message);
            }
        }

        
    }
}
