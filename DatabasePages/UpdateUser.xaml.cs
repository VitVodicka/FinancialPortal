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
    /// Interakční logika pro UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : MetroWindow
    {
        
        public UpdateUser()
        {
            InitializeComponent();
        }



        private void UserUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (changebutton.Text == "Name")
            {
                new Database().UpdateUser("Name", input.Text, dataGrid.SelectedIndex);
            }
            if (changebutton.Text == "Surname")
            {
                new Database().UpdateUser("Surname", input.Text, dataGrid.SelectedIndex);
            }
        }
    }
}
