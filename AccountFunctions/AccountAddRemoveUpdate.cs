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
    internal class AccountAddRemoveUpdate
    {
        static ChartValues<double> AccountChart { get; set; }
        public static double Return { get; set; }
        
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
            
            AccountChart=new ChartValues<double>();
            
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
                Title = "My account",
                Values = AccountChart,
            };

            Chart.SeriesUserCollection.Add(lineseries);

        }
        public void profitLoss()
        {
            
             if(AccountChart.Count == 1)
            {
                ProfitLoss = 0;
            }
            else
            {
                
                ProfitLoss = AccountChart.Last() - AccountChart.First();

            }
        }
        public void calculateReturn()
        {
            double firstValue = 0;
            double lastValue = 0;
            if (AccountChart.Count > 1)
            {
                
                
                firstValue = AccountChart[0];
                lastValue= AccountChart.Last();
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
