using FinancialPortal.Accounts;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
        
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void UserUpdate_Click(object sender, RoutedEventArgs e)
        {
            try { 
            
            if (changebutton.Text != "" && (dataGrid.SelectedIndex > -1))
            {

            if (changebutton.Text == "Name")
            {
                Controller.updateUser(dataGrid.SelectedIndex, "Name", input.Text);               
                this.Close();
            }
            if (changebutton.Text == "Surname")
            {
                Controller.updateUser(dataGrid.SelectedIndex, "Surname", input.Text);
                this.Close();
            }
            }
            else
            {
                MessageBox.Show("Not changed value or not selcted value to change");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("User_Update_click"+ex.Message);
            }
        }
    }
}
