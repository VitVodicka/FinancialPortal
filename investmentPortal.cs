using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;

namespace FinancialPortal
{
    internal class investmentPortal:INotifyPropertyChanged
    {
        public double FinalAmount { get; set; }
        public string Return { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;
        ChartValues<double> investedValues { get; set; }
        ChartValues<double> notInvestedValues { get; set; }
        public investmentPortal()
        {
            investedValues = new ChartValues<double>();
            notInvestedValues = new ChartValues<double>();
        }

        public void Onetime(double initialinvest, double yearsinvestment, double expectedreturn)
        {
            notInvestedValues.Clear();
            investedValues.Clear();
            double blankReturn;
            blankReturn= expectedreturn / 100;
            double finalpercentage = 0;


            double invested=0;
            for (int i = 0; i < yearsinvestment; i++)
            {
                if (i == 0)
                {
                    invested = initialinvest + (initialinvest * blankReturn);
                    investedValues.Add(invested);
                    notInvestedValues.Add(initialinvest);
                }
                else
                {
                    invested +=  (invested * blankReturn);
                    investedValues.Add(invested);
                    notInvestedValues.Add(initialinvest);
                }
                
                
            }
            finalpercentage = (invested / initialinvest)-1;
            finalpercentage = finalpercentage * 100;
            finalpercentage = Math.Round(finalpercentage, 2);
            
            FinalAmount = Math.Round(invested,2);
            Return = finalpercentage.ToString() + "%";

            Change("FinalAmount");
            Change("Return");

            AddingToChart();
            
            
        }
        public void MonthlyContribution(double initialinvestment, double yearsinvestment, double expectedreturn, double contributionsinput)
        {
            notInvestedValues.Clear();
            investedValues.Clear();
            double blankReturn=expectedreturn / 100;
        }
        public void Yearlycontribution(double initialinvestment, double yearsinvestment, double expectedreturn, double contributionsinput)
        {
            notInvestedValues.Clear();
            investedValues.Clear();
            double blankReturn = expectedreturn / 100;
            double carryover = initialinvestment;
            double interestOf = 0;
            double finalpercentage = 0;
            for (int i = 0; i < yearsinvestment; i++)
            {
                
                carryover += contributionsinput;
                interestOf = carryover * blankReturn;
                carryover += interestOf;
                investedValues.Add(carryover);
                notInvestedValues.Add(initialinvestment);
                
            }

            FinalAmount = Math.Round(carryover,2);

            finalpercentage = (carryover / initialinvestment) - 1;
            finalpercentage = finalpercentage * 100;
            finalpercentage = Math.Round(finalpercentage, 2);


            Return = finalpercentage.ToString()+"%";



            Change("FinalAmount");
            Change("Return");
            AddingToChart();

        }
        public void AddingToChart()
        {
            Chart.SeriesCollection.Clear();
            Chart.SeriesCollection.Add(new LineSeries
            {
                Title = "Money not invested",
                Values = notInvestedValues,
            });
            Chart.SeriesCollection.Add(new LineSeries
            {
                Title = "Money invested",
                Values = investedValues,
            });
        }

        public void Change(string change)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(change));
            }
        }
    }
}
