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
        investmentPortal invest = new investmentPortal();
        
        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = m;
            Cartesianchart.Series = Chart.SeriesCollection;
            

            
            
            
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
                    try { 
                    if (repaymentperiod.Text == "monthly")
                    {
                        DataContext = m;
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 1, double.Parse(year.Text));
                    }
                    if (repaymentperiod.Text == "quartely")
                    {
                        DataContext = m;
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 3, double.Parse(year.Text));
                    }
                    if (repaymentperiod.Text == "half yearly")
                    {
                        DataContext = m;
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 6, double.Parse(year.Text));
                    }
                    if (repaymentperiod.Text == "yearly")
                    {
                        DataContext = m;
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 12, double.Parse(year.Text));
                    }
                    }
                    catch
                    {

                    }

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

        private void yearlyContribution_Checked(object sender, RoutedEventArgs e)
        {
            contributions.Content = "yearly contributions";
            contributions.Visibility = Visibility.Visible;
            contributionsinput.Visibility = Visibility.Visible;
        }

        private void monthlyContribution_Checked(object sender, RoutedEventArgs e)
        {
            contributions.Content = "monthly contributions";
            contributions.Visibility = Visibility.Visible;  
            contributionsinput.Visibility = Visibility.Visible;
        }

        private void onetime_Checked(object sender, RoutedEventArgs e)
        {
            contributions.Visibility = Visibility.Collapsed;
            contributionsinput.Visibility = Visibility.Collapsed;
        }

        private void Investment_Click(object sender, RoutedEventArgs e)
        {
            var regex = new Regex("(([A-Z])|([a-z])|([ ]))");
            if ((regex.IsMatch(initialinvestment.Text) == false) && (regex.IsMatch(yearsinvestement.Text) == false) && (regex.IsMatch(expectedreturn.Text) == false))
            {
                if ((initialinvestment.Text != null) && (yearsinvestement.Text != null) && (expectedreturn.Text != null))
                {
                    try
                    {
                        if (onetime.IsChecked == true)
                        {
                            DataContext = invest;
                            invest.Onetime(double.Parse(initialinvestment.Text), double.Parse(yearsinvestement.Text), double.Parse(expectedreturn.Text));
                        }
                    }
                    catch
                    {

                    }



                    if (monthlyContribution.IsChecked == true)
                    {
                        try
                        {
                            if ((regex.IsMatch(contributionsinput.Text) == false) && (contributionsinput.Text) != null)
                            {
                                DataContext = invest;
                                invest.MonthlyContribution(double.Parse(initialinvestment.Text), double.Parse(yearsinvestement.Text), double.Parse(expectedreturn.Text), double.Parse(contributionsinput.Text));
                            }
                        }
                        catch
                        {

                        }
                    }
                    if (yearlyContribution.IsChecked == true)
                    {
                        try
                        {
                            if ((regex.IsMatch(contributionsinput.Text) == false) && (contributionsinput.Text) != null)
                            {
                                DataContext = invest;
                                invest.Yearlycontribution(double.Parse(initialinvestment.Text), double.Parse(yearsinvestement.Text), double.Parse(expectedreturn.Text), double.Parse(contributionsinput.Text));
                            }
                        }
                        catch
                        {

                        }
                    }
                    /*if(onetimeNotCompounded.IsChecked == true)
                        {
                            try
                            {
                                DataContext = invest;
                                invest.OnetimeNotCompounded(double.Parse(initialinvestment.Text), double.Parse(yearsinvestement.Text), double.Parse(expectedreturn.Text));
                            }
                            catch {
                            }
                        }

                    }*/
                }
                else
                {

                    //hint.Text = "*Text must only contain numbers";

                }
            }

        }
    }
}
