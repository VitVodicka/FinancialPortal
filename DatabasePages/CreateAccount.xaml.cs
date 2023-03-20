using FinancialPortal.Accounts;
using MahApps.Metro.Controls;
using System.Windows;

namespace FinancialPortal.DatabasePages
{
    /// <summary>
    /// Interakční logika pro CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : MetroWindow
    {
        //Database d = new Database();
        
        Account account;
        public CreateAccount()
        {
            
            InitializeComponent();
            
            
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller control = new Controller();

                // check if the name and deposit fields are not empty and a user is selected from the drop-down list
                if ((name.Text != "") && (deposit.Text != "") && (users.SelectedIndex > -1))
                {
                   
                    account = new Account(name.Text, float.Parse(deposit.Text), users.SelectedIndex);

                    // convert the account object to string representation
                    account.fromCollectionToString();

                    // add the account to the list of accounts in the controller
                    Controller.addAccount(account);

                    // update the list of account names in the controller
                    control.NameFromObservable();
                    new Database().AddingAccount(name.Text, float.Parse(deposit.Text), Controller.UserListObservable[users.SelectedIndex].Id);
                    this.Close();

                }
                else
                {

                    MessageBox.Show("Not changed value or not selected value to change");
                }
            }
            catch
            {

                MessageBox.Show("Bad input");
            }
        }
    }
}
