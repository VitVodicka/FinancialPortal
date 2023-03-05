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
        static ChartValues<double> AccountChart { get; set; }
        public double Return { get; set; }
        public double ProfitLoss { get; set; }
        public AccountAddRemoveUpdate() { 
        }
        static AccountAddRemoveUpdate()
        {
            
            AccountChart=new ChartValues<double>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Change(string change)//changing properties
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(change));
            }
        }

        public void UpdateMoney(double money)
        {
            
                AccountChart.Add(money);
                AddingToChart();
                profitLoss();
                calculateReturn();
            
            
            
        }
        public void AddingToChart()
        {
            Chart.SeriesUserCollection.Clear();//clearing of the chart
            LineSeries lineseries = new LineSeries
            {
                Title = "My money",
                Values = AccountChart,
            };

            Chart.SeriesUserCollection.Add(lineseries);

        }
        public void profitLoss()
        {
            if (AccountChart.Count == 0)
            {
                ProfitLoss = 2;
                Change("ProfitLoss");
            }
            else if(AccountChart.Count == 1)
            {
                ProfitLoss = 2;
                //ProfitLoss = AccountChart.First();
                Change("ProfitLoss");
            }
            else
            {
                ProfitLoss = AccountChart.Last() - AccountChart.First();
                Change("ProfitLoss");
            }
        }
        public void calculateReturn()
        {
            double firstValue = 0;
            double lastValue = 0;
            if (AccountChart.Count > 1)
            {
                Return = 2;
                //firstValue = AccountChart[0];
                //lastValue= AccountChart.Last();
                //Return = lastValue / firstValue;
                //Return= Math.Round(Return, 2);
                Change("Return");


            }
            else
            {
                Return = 2;
                Change("Return");
            }

        }
    }
}
