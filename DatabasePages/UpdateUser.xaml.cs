using FinancialPortal.Accounts;
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
    /// Interakční logika pro updateUser.xaml
    /// </summary>
    public partial class UpdateUser : MetroWindow
    {
        //Database d = new Database();
        
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void UserUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (changebutton.Text != null)
            {

            
            if (changebutton.Text == "Name")
            {
                Controller.updateUser(dataGrid.SelectedIndex, "Name", input.Text);
                //MessageBox.Show(d.updateUser("Name", input.Text, dataGrid.SelectedIndex));
                this.Close();
            }
            if (changebutton.Text == "Surname")
            {
                Controller.updateUser(dataGrid.SelectedIndex, "Surname", input.Text);
                //MessageBox.Show(d.updateUser("Surname", input.Text, dataGrid.SelectedIndex));
                this.Close();
            }
            }
        }
    }
}
