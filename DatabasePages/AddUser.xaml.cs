using MahApps.Metro.Controls;
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
    /// Interakční logika pro AddUser.xaml
    /// </summary>
    public partial class AddUser : MetroWindow
    {
        Database d = new Database();
        public AddUser()
        {
            InitializeComponent();
        }

        

        private void USER_ADD_CLICK(object sender, RoutedEventArgs e)
        {
      
            MessageBox.Show(d.AddingUser(UserName.Text, Surname.Text));
            
            
        }
    }
}
