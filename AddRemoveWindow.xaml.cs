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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinancialPortal
{
    /// <summary>
    /// Interakční logika pro AddRemoveWindow.xaml
    /// </summary>
    public partial class AddRemoveWindow : MetroWindow
    {
        public AddRemoveWindow()
        {
            InitializeComponent();
        }

        private void MONEY_ADD_CLICK(object sender, RoutedEventArgs e)
        {
            AccountAddRemoveUpdate account = new AccountAddRemoveUpdate();
            if(input.Text!=null)
            {
                
               account.UpdateMoney(double.Parse(input.Text));
                

            }
            
            this.Close();
        }
    }
}
