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
            var regex = new Regex("@");
            PasswordChecker ps = new PasswordChecker();
            if (regex.IsMatch(mail.Text) != false)
            {
               
            
            if ((mail.Text != "")&&(passwordInput.Password!=""))
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
                MessageBox.Show("Email dosen t contain @");
            }

        }
    }
}
