using FinancialPortal.Accounts;
using FinancialPortal.DatabasePages;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FinancialPortal
{
    /// <summary>
    /// Interakční logika pro TitleSetup.xaml
    /// </summary>
    public partial class TitleSetup : Window
    {
        public TitleSetup()
        {
            InitializeComponent();
        }

        bool hiddenUser = false;
        bool hiddenAccount = false;

        // Event handler for the "Setup" button click
        private void Setup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if both user and account details have been set up
                if (hiddenAccount == true && hiddenUser == true)
                {
                    this.Close();
                    new Files().WrittingToFile(2);  // Write to the fail to not open again
                    new MainWindow().Visibility = Visibility.Visible;  // Show the main application window
                }
                else
                {
                    MessageBox.Show("User or Account is not set up");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler for the "Add User" button click
        private void UserAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUser user = new AddUser();
            user.Show();
            user.Closed += (s, args) => hideUserButton();
        }

        // Hide the "Add User" button and show a text label when a user has been added
        private void hideUserButton()
        {
            if (Controller.UserListObservable.Count > 0)
            {
                userAddButton.Visibility = Visibility.Collapsed;
                usertext.Visibility = Visibility.Visible;
                hiddenUser = true;
            }
        }

        // Hide the "Add Account" button and show a text label when an account has been added
        private void hideAccountButton()
        {
            if (Controller.AccountListObservable.Count > 0)
            {
                accountAdd.Visibility = Visibility.Collapsed;
                accounttext.Visibility = Visibility.Visible;
                hiddenAccount = true;
            }
        }

        // Event handler for the "Add Account" button click
        private void AccountAdd_Click(object sender, RoutedEventArgs e)
        {
            if (usertext.Visibility == Visibility.Visible)
            {
                CreateAccount acc = new CreateAccount();
                acc.Show();
                acc.Closed += (s, args) => hideAccountButton();
            }
            else
            {
                MessageBox.Show("No user has been added");
            }
        }
    }
}
