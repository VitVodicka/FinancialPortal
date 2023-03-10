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
            try { 
            var regex = new Regex("@");
            var regexText = new Regex("([A-Z])|([a-z])");
            PasswordChecker ps = new PasswordChecker();
            if (regex.IsMatch(mail.Text) != false)
            {
                if ((regexText.IsMatch(passwordInput.Password) == true)&&(passwordInput.Password.Length>7))
                {
                    if ((mail.Text != "") && (passwordInput.Password != ""))
                    {
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
            catch(Exception ex) 
            {
                MessageBox.Show("CheckPassword"+ex.Message);
            }
        }
    }
}
