using FinancialPortal.Accounts;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class AccountAddRemoveUpdate:INotifyPropertyChanged
    {
        public static double Return { get; set; }
        private static ChartValues<double> chartHelpfulValues { get; set; }
        
        public static double ProfitLoss
        {
        get;set;
        }
        public AccountAddRemoveUpdate() { 
        }
        static AccountAddRemoveUpdate()
        {
            Return = 0;
            ProfitLoss = 0;

            chartHelpfulValues = new ChartValues<double>();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void change(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public void UpdateMoney(double money, int index)
        {
                for(int i =0;i< Controller.AccountListObservable.Count;i++)
                {
                if (i == index)
                {
                    Controller.AccountListObservable[i].MoneyStatus.Add(money);
                    chartHelpfulValues = Controller.AccountListObservable[i].MoneyStatus;
                    
                    AddingToChart(Controller.AccountListObservable[i].MoneyStatus, Controller.AccountNames[i]);
                    profitLoss();
                    calculateReturn();
                }
                }
                   
        }
        public void UpdateWithoutMoney(int index)
        {
            for (int i = 0; i < Controller.AccountListObservable.Count; i++)
            {
                if (i == index)
                {
                   
                    chartHelpfulValues = Controller.AccountListObservable[i].MoneyStatus;

                    AddingToChart(Controller.AccountListObservable[i].MoneyStatus, Controller.AccountNames[i]);
                    profitLoss();
                    calculateReturn();
                }
            }

        }
        public void AddingToChart(ChartValues<double> accountChart, string name)
        {
            Chart.SeriesUserCollection.Clear();//clearing of the chart
            LineSeries lineseries = new LineSeries
            {
                Title = name,
                Values = accountChart,
            };

            Chart.SeriesUserCollection.Add(lineseries);

        }
        public void profitLoss()
        {
            
             if(chartHelpfulValues.Count == 1)
            {
                ProfitLoss = 0;
            }
            else
            {
                
                ProfitLoss = chartHelpfulValues.Last() - chartHelpfulValues.First();

            }
        }
        public void calculateReturn()
        {
            double firstValue = 0;
            double lastValue = 0;
            if (chartHelpfulValues.Count > 1)
            {
                
                
                firstValue = chartHelpfulValues[0];
                lastValue= chartHelpfulValues.Last();
                Return = (lastValue / firstValue)-1;
                
                Return= Math.Round(Return, 2);
            }
            else
            {
                Return = 0;

            }

        }
    }
}
