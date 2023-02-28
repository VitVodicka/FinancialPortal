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
            if ((type.Text != "") && (name.Text != "") && (deposit.Text != "") && (users.SelectedIndex > -1))
            {

            
            if (type.Text == "Current account")
            {


                account = new Account(name.Text, float.Parse(deposit.Text), users.SelectedIndex, "Current account");
                Controller.addAccount(account);
                this.Close();
               // MessageBox.Show(d.AddingAccount(name.Text, deposit.Text, users.SelectedIndex.ToString(), "Current account"));
            }
            if (type.Text == "Saving account")
            {
                account = new Account(name.Text, float.Parse(deposit.Text), users.SelectedIndex, "Saving account");
                
                Controller.addAccount(account);
                this.Close();
                //MessageBox.Show(d.AddingAccount(name.Text, deposit.Text, users.SelectedIndex.ToString(), "Saving account"));
            }
            }
        }
    }
}
