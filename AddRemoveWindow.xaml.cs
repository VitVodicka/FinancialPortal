using FinancialPortal.Accounts;
using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinancialPortal
{
    /// <summary>
    /// Interakční logika pro AddRemoveWindow.xaml
    /// </summary>
    public partial class AddRemoveWindow : MetroWindow
    {
        int indexWindow = 0;
        public AddRemoveWindow(int index)
        {
            indexWindow= index;
            InitializeComponent();
        }

        private void MONEY_ADD_CLICK(object sender, RoutedEventArgs e)
        {
            try {
            AccountAddRemoveUpdate account = new AccountAddRemoveUpdate();
            var regex = new Regex("(([A-Z])|([a-z])|([ ]))");//regex filter
            if (regex.IsMatch(input.Text) == false)
            {

            
            if (input.Text!="")
            {
                
               account.UpdateMoney(double.Parse(input.Text),indexWindow);
               new Database().updateMoney(Controller.AccountListObservable[indexWindow].Index,float.Parse(input.Text));
            }
            }

            this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Money_ADD_Click"+ex.Message);
            }
        }
    }
}
