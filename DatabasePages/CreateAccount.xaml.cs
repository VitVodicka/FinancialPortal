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
            
            //users.ItemsSource=control.User
            //what was before in users
            //ItemsSource="{Binding Source={x:Static d:Controller.UserListObservable}}" SelectedValuePath="Name" SelectedValue="{Binding Path=Controller.UserListObservable}" DisplayMemberPath="Name" 
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            Controller control = new Controller();
            if ((name.Text != "") && (deposit.Text != "") && (users.SelectedIndex > -1))
            {
                account = new Account(name.Text, float.Parse(deposit.Text), users.SelectedIndex);
                account.fromCollectionToString();
                Controller.addAccount(account);
                this.Close();
                
            }
        }
    }
}
