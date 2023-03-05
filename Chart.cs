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
        public static SeriesCollection SeriesCollectionPieChart { get; set; }//declaration of collections
        public static SeriesCollection SeriesCollection { get; set; }
        public static SeriesCollection SeriesUserCollection { get; set; }
        public Chart()
        {
            SeriesCollection = new SeriesCollection()
            {
                

            };
            SeriesCollectionPieChart = new SeriesCollection()
            {
                
            };
            SeriesUserCollection = new SeriesCollection()
            {

            };
        }
        
    }
}
