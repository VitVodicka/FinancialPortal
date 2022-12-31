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
    /// Interakční logika pro UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : MetroWindow
    {
        //Database d = new Database();
        Controller control = new Controller();
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void UserUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (changebutton.Text == "Name")
            {
                control.UpdateUser(dataGrid.SelectedIndex, "Name", input.Text);
                //MessageBox.Show(d.UpdateUser("Name", input.Text, dataGrid.SelectedIndex));
                this.Close();
            }
            if (changebutton.Text == "Surname")
            {
                control.UpdateUser(dataGrid.SelectedIndex, "Surname", input.Text);
                //MessageBox.Show(d.UpdateUser("Surname", input.Text, dataGrid.SelectedIndex));
                this.Close();
            }
        }
    }
}
