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
using MahApps.Metro;
using MahApps.Metro.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace FinancialPortal
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Mortgage m = new Mortgage();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = m;
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            repayment();

        }
        public void repayment() {

            if (repaymentperiod.Text == "monthly")
            {
                m.Calculate(int.Parse(loanamount.Text), int.Parse(interestrate.Text), 12);
            }
            if (repaymentperiod.Text == "quartely")
            {
                m.Calculate(int.Parse(loanamount.Text), int.Parse(interestrate.Text), 4);
            }
            if (repaymentperiod.Text == "yearly")
            {
                m.Calculate(int.Parse(loanamount.Text), int.Parse(interestrate.Text), 1);
            }
        }



    }
}
