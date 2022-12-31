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
    /// Interakční logika pro UpdateAccount.xaml
    /// </summary>
    public partial class UpdateAccount : MetroWindow
    {
        Database d = new Database();
        public UpdateAccount()
        {
            InitializeComponent();
        }

        

        private void UppdateAccount_click(object sender, RoutedEventArgs e)
        {

            choosingParametrs();
        }
        public void choosingParametrs()
        {
            if (change.Text =="Name")
            {
                MessageBox.Show(d.UpdateAccount("Name",input.Text,datagrid.SelectedIndex));
                this.Close();
            }
            if (change.Text == "User")
            {
                MessageBox.Show(d.UpdateAccount("User", input.Text, datagrid.SelectedIndex));
                this.Close();
            }
            if (change.Text == "Type")
            {
                MessageBox.Show(d.UpdateAccount("Type", input.Text, datagrid.SelectedIndex));
                this.Close();
            }
            if (change.Text == "MoneyStatus")
            {
                MessageBox.Show(d.UpdateAccount("MoneyStatus", input.Text, datagrid.SelectedIndex));
                this.Close();
            }
        }
    }
}
