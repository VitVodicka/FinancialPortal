﻿using LiveCharts;
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
        public static SeriesCollection SeriesCollection { get; set; }
        public Chart()
        {
            SeriesCollection = new SeriesCollection()
            {
                

            };
        }
    }
}
