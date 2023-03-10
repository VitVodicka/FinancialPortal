using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interakční logika pro RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void CheckPassword(object sender, RoutedEventArgs e)
        {
            try
            {
                // Define two regular expressions to match the email format and password strength
                var regex = new Regex("@");
                var regexText = new Regex("([A-Z])|([a-z])");

                
                PasswordChecker ps = new PasswordChecker();

                // Check if the email format is valid
                if (regex.IsMatch(mail.Text) != false)
                {
                    // Check if the password is strong enough
                    if ((regexText.IsMatch(passwordInput.Password) == true) && (passwordInput.Password.Length > 7))
                    {
                        // Check if both email and password fields are filled in
                        if ((mail.Text != "") && (passwordInput.Password != ""))
                        {
                            // Set the email and password in the PasswordChecker class and open the TitleSetup window
                            ps.setEmail(mail.Text);
                            ps.setPassword(passwordInput.Password);
                            this.Close();
                            new TitleSetup().Show();
                        }
                        else
                        {
                            MessageBox.Show("Not inserted password or E-mail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The password must be at least 8 characters long and contain at least one letter to be considered strong");
                    }
                }
                else
                {
                    MessageBox.Show("Email doesn't contain @");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CheckPassword" + ex.Message);
            }
        }
    }
}
