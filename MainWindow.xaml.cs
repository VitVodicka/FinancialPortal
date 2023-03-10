﻿using System;
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
using FinancialPortal.DatabasePages;
using System.Data.SqlClient;
using System.Security.Principal;
using FinancialPortal.Accounts;
using ControlzEx.Standard;

namespace FinancialPortal
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Chart chare = new Chart();
        Mortgage m = new Mortgage();//creating classes  
        investmentPortal invest = new investmentPortal();
        PasswordChecker ps = new PasswordChecker();
        
        //Database dat = new Database();
        

        public MainWindow()
        {
            
            
            
            InitializeComponent();
            HamburgerMenu.SelectedItem = HamburgerMenu.TabIndex= 0;

            returnMoney.Text = (AccountAddRemoveUpdate.Return * 100).ToString() + "%";
            profitLoss.Text = AccountAddRemoveUpdate.ProfitLoss.ToString();

            chartCombobox.ItemsSource = Controller.AccountNames;
            userchart.Series = Chart.SeriesUserCollection;
            Cartesianchart.Series = Chart.SeriesCollection;//adding itemsosurce to the charts
            piechart.Series = Chart.SeriesCollectionPieChart;
            
            
            investgrid.DataContext = invest;//declaring datacontext for every grid
            mortgageGrid.DataContext = m;//declaring datacontext for every grid

            if(Chart.SeriesUserCollection.Count < 1) {
            userchart.Visibility= Visibility.Collapsed;
            }
            if(Chart.SeriesCollectionPieChart.Count < 1)
            {
                Cartesianchart.Visibility= Visibility.Collapsed;
            }
            try { 
            //dat.DataBaseConnection();
            if (new Files().ReadingFromFile() == 1)
            {
                new RegisterWindow().Show();
                TitleSetup title = new TitleSetup();
                this.Visibility = Visibility.Hidden;
                
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Files loading"+ex.Message);
            }

            this.Closed += (s, args) => Application.Current.Shutdown();


        }
        private void HamburgerMenuControle(object sender, ItemClickEventArgs e)
        {
            HamburgerMenu.SetCurrentValue(ContentProperty, e.ClickedItem);
            HamburgerMenu.SetCurrentValue(HamburgerMenu.IsPaneOpenProperty, false);//setting values to the hamburgermenu, and closing hamburgermenu after selection
            
        }
        
        void showAddUser()
        {
            if (ps.getValueFromPassword())//if the inputed value equals to the password then it shows the window
            {
                new AddUser().ShowDialog();
            }
            else
            {
                MessageBox.Show("Bad password");
            }
        }
        private void AddUserClick(object sender, RoutedEventArgs e)
        {
            try { 
            Password password = new Password();
            password.Show();
            password.Closed+=(s,args)=> showAddUser();//s= Password window, args=parametrs with Password window, adding a method of Closed window and if closed the does function
            }
            catch(Exception ex)
            {
                MessageBox.Show("AddUserClick"+ex.Message);
            }
        }
        void showUpdateUser()
        {
            if (ps.getValueFromPassword())//if the inputed value equals to the password then it shows the window
            {
                new UpdateUser().ShowDialog();
            }
            else
            {
                MessageBox.Show("Bad password");
            }
        }
        private void UpdateUserClick(object sender, RoutedEventArgs e)
        {
            Password password = new Password();
            password.Show();
            password.Closed += (s, args) => showUpdateUser();//s= Password window, args=parametrs with Password window, adding a method of Closed window and if closed the does function
          
        }
 
        void showAddAccount()
        {
            if (ps.getValueFromPassword())//if the inputed value equals to the password then it shows the window
            {
                new CreateAccount().ShowDialog();
            }
            else
            {
                MessageBox.Show("Bad password");
            }
        }
        private void AddAccountClick(object sender, RoutedEventArgs e)
        {
            Password password = new Password();
            password.Show();
            password.Closed += (s, args) => showAddAccount();//s= Password window, args=parametrs with Password window, adding a method of Closed window and if closed the does function



        }
        void showUpdateAccount()
        {
            if (ps.getValueFromPassword())//if the inputed value equals to the password then it shows the window
            {
                new UpdateAccount().ShowDialog();
            }
            else
            {
                MessageBox.Show("Bad password");
            }
        }
        private void UpdateAccountClick(object sender, RoutedEventArgs e)
        {
            Password password = new Password();
            password.Show();
            password.Closed += (s, args) => showUpdateAccount();//s= Password window, args=parametrs with Password window, adding a method of Closed window and if closed the does function

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            repayment();//chosing functions according to selected options
            switchingQuaters();

        }

        public void switchingQuaters()
        {
            switch (repaymentperiod.Text)
            {//text swtiching according to timepayment selected
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
            try { 
            var regex = new Regex("(([A-Z])|([a-z])|([ ]))");//regex filter
            
            if ((regex.IsMatch(loanamount.Text) == false) && (regex.IsMatch(interestrate.Text) == false) && (regex.IsMatch(year.Text) == false)){//if it matches and isn t context null than do this


                if ((repaymentperiod.Text != "") && (loanamount.Text != ""  ) && (interestrate.Text != "") && (year.Text != ""))
                {
                    if ((double.Parse(interestrate.Text) < 50) && (double.Parse(loanamount.Text) < 50000000) && (double.Parse(year.Text) < 30)) {
                    if (repaymentperiod.Text == "monthly")
                    {
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 1, double.Parse(year.Text));//using functions
                    }
                    if (repaymentperiod.Text == "quartely")
                    {
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 3, double.Parse(year.Text));//using functions
                    }
                    if (repaymentperiod.Text == "half yearly")
                    {
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 6, double.Parse(year.Text));//using functions
                    }
                    if (repaymentperiod.Text == "yearly")
                    {
                        m.Calculate(double.Parse(loanamount.Text), double.Parse(interestrate.Text), 12, double.Parse(year.Text));//using functions
                    }
                    }
                    else
                    {
                        MessageBox.Show("Too big mortgage value");
                    }
                }
                
            }

            else
            {
                hint.Text = "*Text must only contain numbers";
            }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    

        private void periodchanging(object sender, RoutedEventArgs e)//switches quater if it lost focus
        {
            switchingQuaters();
        }

        private void yearlyContribution_Checked(object sender, RoutedEventArgs e)//if selected then contributions appears
        {
            contributions.Content = "yearly contributions";
            contributions.Visibility = Visibility.Visible;
            contributionsinput.Visibility = Visibility.Visible;
        }

        private void monthlyContribution_Checked(object sender, RoutedEventArgs e)//if selected then contributions appears
        {
            contributions.Content = "monthly contributions";
            contributions.Visibility = Visibility.Visible;  
            contributionsinput.Visibility = Visibility.Visible;
        }

        private void onetime_Checked(object sender, RoutedEventArgs e)//the contributions input is not visible
        {
            contributions.Visibility = Visibility.Collapsed;
            contributionsinput.Visibility = Visibility.Collapsed;
        }
        void updateReturnProfitLoss()
        {
            returnMoney.Text = (AccountAddRemoveUpdate.Return*100).ToString()+"%";
            profitLoss.Text = AccountAddRemoveUpdate.ProfitLoss.ToString();
        }
        private void ShowAddMoney(object sender, RoutedEventArgs e)
        {
            try { 
            if (chartCombobox.SelectedIndex > -1)
            {
                AddRemoveWindow add = new AddRemoveWindow(chartCombobox.SelectedIndex);
                add.Show();
                add.Closed += (s, args) => updateReturnProfitLoss();
                
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ShowAddMoney"+ex.Message);
            }


        }
        private void Investment_Click(object sender, RoutedEventArgs e)
        {
            try { 
            var regex = new Regex("(([A-Z])|([a-z])|([ ]))");

            if ((regex.IsMatch(initialinvestment.Text) == false) && (regex.IsMatch(yearsinvestement.Text) == false) && (regex.IsMatch(expectedreturn.Text) == false))
            {
                if ((double.Parse(initialinvestment.Text) < 50000000) && (double.Parse(yearsinvestement.Text) < 15) && (double.Parse(expectedreturn.Text) < 100))
                {
                    if ((initialinvestment.Text != "") && (yearsinvestement.Text != "") && (expectedreturn.Text != ""))
                    {
                        try
                        {
                            if (onetime.IsChecked == true)
                            {
                                invest.Onetime(double.Parse(initialinvestment.Text), double.Parse(yearsinvestement.Text), double.Parse(expectedreturn.Text));
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Bad input into one time option");
                            
                        }

                        if (monthlyContribution.IsChecked == true)
                        {
                            try
                            {
                                if ((regex.IsMatch(contributionsinput.Text) == false) && (contributionsinput.Text) != "")
                                {
                                    invest.MonthlyContribution(double.Parse(initialinvestment.Text), double.Parse(yearsinvestement.Text), double.Parse(expectedreturn.Text), double.Parse(contributionsinput.Text));
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Bad input into monthly contribution option");
                            }
                        }

                        if (yearlyContribution.IsChecked == true)
                        {
                            try
                            {
                                if ((regex.IsMatch(contributionsinput.Text) == false) && (contributionsinput.Text) != "")
                                {
                                    invest.Yearlycontribution(double.Parse(initialinvestment.Text), double.Parse(yearsinvestement.Text), double.Parse(expectedreturn.Text), double.Parse(contributionsinput.Text));
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Bad input into yearly contribution option");
                            }
                        }
                    }
                    else
                    {
                        hint.Text = "*Text must only contain numbers";
                    }
                }
                else
                {
                    MessageBox.Show("Too big investment value");
                }

                Cartesianchart.Visibility = Visibility.Visible;
            }
            }
            catch(Exception ez)
            {
                MessageBox.Show("investment click"+ez.Message);
            }
        }

        private void chartCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
            AccountAddRemoveUpdate account = new AccountAddRemoveUpdate();
            userchart.Visibility = Visibility.Visible;
            account.UpdateWithoutMoney(chartCombobox.SelectedIndex);
            returnMoney.Text = (AccountAddRemoveUpdate.Return * 100).ToString() + "%";
            profitLoss.Text = AccountAddRemoveUpdate.ProfitLoss.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ChartCombobox:"+ex.Message);
            }
        }
        private void myHamburgerMenu_Loaded(object sender, RoutedEventArgs e)
        {
            HamburgerMenu.SelectedItem = HamburgerMenu.Items[0];

        }

    }
}
