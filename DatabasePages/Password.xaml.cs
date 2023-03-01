using System;
using System.Collections.Generic;
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

namespace FinancialPortal.DatabasePages
{
    /// <summary>
    /// Interakční logika pro Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        
        public Password()
        {
            InitializeComponent();
        }

        private void CheckPassword(object sender, RoutedEventArgs e)
        {
            if (passwordInput.Password.ToString() !="")//if password input contains something, then it passes value to InputPassowrd and closes the window
            {
                PasswordChecker.InputPassword = passwordInput.Password.ToString();
                this.Close();
            }

        }

      

      
    }
}
