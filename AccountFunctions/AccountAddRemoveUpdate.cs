using FinancialPortal.Accounts;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinancialPortal
{
    internal class AccountAddRemoveUpdate
    {

        public static double Return { get; set; }
        // Private property for the values to be used in the chart
        private static ChartValues<double> chartHelpfulValues { get; set; }

        public static double ProfitLoss { get; set; }

        // Static constructor that initializes the class properties
        static AccountAddRemoveUpdate()
        {
            Return = 0;
            ProfitLoss = 0;
            chartHelpfulValues = new ChartValues<double>();
        }

        // Method for updating the account's money balance
        public void UpdateMoney(double money, int index)
        {
            try
            {
                // Iterate through the list of accounts
                for (int i = 0; i < Controller.AccountListObservable.Count; i++)
                {
                    // Find the account with the matching index
                    if (i == index)
                    {
                        // If there are no previous balances, initialize the list with 0 and the new balance
                        if (Controller.AccountListObservable[i].MoneyStatus.Count == 0)
                        {
                            Controller.AccountListObservable[i].MoneyStatus.Add(0);
                            Controller.AccountListObservable[i].MoneyStatus.Add(money);
                        }
                        // Otherwise, simply add the new balance to the list
                        else
                        {
                            Controller.AccountListObservable[i].MoneyStatus.Add(money);
                        }

                        // Update the chart values
                        chartHelpfulValues = Controller.AccountListObservable[i].MoneyStatus;

                        // Update the chart
                        AddingToChart(Controller.AccountListObservable[i].MoneyStatus, Controller.AccountNames[i]);
                        // Update the profit/loss value
                        profitLoss();
                        calculateReturn();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Update Money:" + ex.Message);
            }
        }

        // Method for updating the account without changing the money balance
        public void UpdateWithoutMoney(int index)
        {
            try
            {
                // Iterate through the list of accounts
                for (int i = 0; i < Controller.AccountListObservable.Count; i++)
                {
                    // Find the account with the matching index
                    if (i == index)
                    {
                        // Update the chart values
                        chartHelpfulValues = Controller.AccountListObservable[i].MoneyStatus;

                        // Update the chart
                        AddingToChart(Controller.AccountListObservable[i].MoneyStatus, Controller.AccountNames[i]);
                        // Update the profit/loss value
                        profitLoss();

                        calculateReturn();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Update without money " + ex.Message);
            }
        }
        public void AddingToChart(ChartValues<double> accountChart, string name)
        {
            // Clear the existing chart
            Chart.SeriesUserCollection.Clear();

            // Create a new LineSeries object and add it to the chart
            LineSeries lineseries = new LineSeries
            {
                Title = name,
                Values = accountChart,
            };
            Chart.SeriesUserCollection.Add(lineseries);
        }
        public void profitLoss()
        {
            // If there are only two values in the chart, there is no profit/loss
            if (chartHelpfulValues.Count == 2)
            {
                ProfitLoss = 0;
            }
            // If there are more than two values, calculate the profit/loss as the difference between the last and second value
            if (chartHelpfulValues.Count > 2)
            {
                ProfitLoss = chartHelpfulValues.Last() - chartHelpfulValues[1];
            }
        }
        public void calculateReturn()
        {
            double firstValue = 0;
            double lastValue = 0;

            // If there are more than two values in the chart, calculate the return as (lastValue/firstValue)-1
            if (chartHelpfulValues.Count > 2)
            {
                firstValue = chartHelpfulValues[1];
                lastValue = chartHelpfulValues.Last();
                Return = (lastValue / firstValue) - 1;
                Return = Math.Round(Return, 2);
            }
            // If there are only two values in the chart, there is no return
            else
            {
                Return = 0;
            }
        }
    }
}
