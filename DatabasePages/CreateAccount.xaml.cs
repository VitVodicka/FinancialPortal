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
            try { 
            Controller control = new Controller();
            if ((name.Text != "") && (deposit.Text != "") && (users.SelectedIndex > -1))
            {
                account = new Account(name.Text, float.Parse(deposit.Text), users.SelectedIndex);
                account.fromCollectionToString();
                Controller.addAccount(account);
                control.NameFromObservable();
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
