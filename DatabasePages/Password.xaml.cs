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
        PasswordChecker ps = new PasswordChecker();
        public Password()
        {
            InitializeComponent();
        }

        private void CheckPassword(object sender, RoutedEventArgs e)
        {
            if (ps.returnValueFromPassword(passwordInput.Password.ToString()) == true)
            {

            }

        }
    }
}
