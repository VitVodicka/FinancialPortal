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
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace FinancialPortal
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Mortgage m = new Mortgage();
        Chart chare = new Chart();
        
        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = m;
            Cartesianchart.Series = chare.SeriesCollection;
            

            
            
            
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            repayment();
            switchingQuaters();

        }
        public void switchingQuaters()
        {
            switch (repaymentperiod.Text)
            {
                case "monthly":
                    timepayment.Content = "Monthly payment";
                    break;
                case "quartely":
                    timepayment.Content = "Quartely payment";
                    break;
                case "half yearly":
                    timepayment.Content = "Half yearly payment";
                    break;
                case "yearly":
                    timepayment.Content = "Yearly payment";
                    break;
                default:
                    timepayment.Content = "Monthly payment";
                    break;

            }
        }

        public void repayment() {
            var regex = new Regex("(([A-Z])|([a-z])|([ ]))");
            
            if ((regex.IsMatch(loanamount.Text) == false) && (regex.IsMatch(interestrate.Text) == false) && (regex.IsMatch(year.Text) == false)){


                if ((repaymentperiod.Text != null) && (loanamount.Text != null) && (interestrate.Text != null) && (year.Text != null))
                {
                    if (repaymentperiod.Text == "monthly")
                    {
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 1, double.Parse(year.Text));
                    }
                    if (repaymentperiod.Text == "quartely")
                    {
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 3, double.Parse(year.Text));
                    }
                    if (repaymentperiod.Text == "half yearly")
                    {
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 6, double.Parse(year.Text));
                    }
                    if (repaymentperiod.Text == "yearly")
                    {
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 12, double.Parse(year.Text));
                    }
                }
                else
                {
                    hint.Text = "*Not selected a repayment period";
                }
            }

            else
            {
                hint.Text = "*Text must only contain numbers";
            }
        }
    

        private void periodchanging(object sender, RoutedEventArgs e)
        {
            switchingQuaters();
        }
    }
}
