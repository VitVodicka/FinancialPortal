using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class Chart
    {
        public  SeriesCollection SeriesCollection { get; set; }
        public Chart()
        {
            SeriesCollection = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = "firstrow",
                    Values= new ChartValues<double>{4,8,6,9}
                },
                new LineSeries
                {
                    Title = "secondrow",
                    Values= new ChartValues<double>{3,7,10,12}
                },
                new ColumnSeries
                {
                    Title = "firstcolumn",
                    Values=new ChartValues<double>{5,10,15,20}
                },
                new ColumnSeries
                {
                    Title = "firstcolumn",
                    Values=new ChartValues<double>{5,10,15,20}
                }

            };
        }
    }
}
