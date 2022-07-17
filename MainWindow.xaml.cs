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
            if((repaymentperiod.Text != null)&&(loanamount.Text!=null) &&(interestrate.Text!=null) &&(year.Text!=null)) { 
            if (repaymentperiod.Text == "monthly")
            {
                m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 12,double.Parse(year.Text));
            }
            if (repaymentperiod.Text == "quartely")
            {
                m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 4, double.Parse(year.Text));
            }
            if (repaymentperiod.Text == "yearly")
            {
                m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 1, double.Parse(year.Text));
            }
            }
            else
            {
                hint.Text = "*Not selected a repayment period";
            }
        }



    }
}
