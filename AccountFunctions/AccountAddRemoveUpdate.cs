using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class AccountAddRemoveUpdate
    {
        ChartValues<double> AccountChart { get; set; }
        public AccountAddRemoveUpdate()
        {
            AccountChart=new ChartValues<double>();
        }
        public void UpdateMoney(double money)
        {
            //AccountChart.Add(money);
            AddingToChart();
            
        }
        public void AddingToChart()
        {
            //Chart.SeriesCollection.Clear();//clearing of the chart
            LineSeries lineSeries = new LineSeries
            {
                Title = "My Line Series",
                Values = new ChartValues<double> { 10, 20, 30, 40, 50 }
            };

            Chart.SeriesCollection.Add(lineSeries);

        }
    }
}
