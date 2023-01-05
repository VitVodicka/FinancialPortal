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
        Controller control = new Controller();
        Account account;
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            if ((type.Text != null) && (name.Text != null) && (deposit.Text != null) && (users.SelectedIndex >= 0))
            {

            
            if (type.Text == "Current account")
            {


                account = new Account(name.Text, float.Parse(deposit.Text), users.SelectedIndex, "Current account");
                control.addAccount(account);
                this.Close();
               // MessageBox.Show(d.AddingAccount(name.Text, deposit.Text, users.SelectedIndex.ToString(), "Current account"));
            }
            if (type.Text == "Saving account")
            {
                account = new Account(name.Text, float.Parse(deposit.Text), users.SelectedIndex, "Saving account");
                control.addAccount(account);
                this.Close();
                //MessageBox.Show(d.AddingAccount(name.Text, deposit.Text, users.SelectedIndex.ToString(), "Saving account"));
            }
            }
        }
    }
}
