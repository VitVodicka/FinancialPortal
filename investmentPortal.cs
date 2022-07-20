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
                    notInvestedValues.Add(0);
                    investedValues.Add(0);

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
            Yearlycontribution(initialinvestment,yearsinvestment,expectedreturn,(contributionsinput*12));
        }
        public void Yearlycontribution(double initialinvestment, double yearsinvestment, double expectedreturn, double contributionsinput)
        {
            notInvestedValues.Clear();
            investedValues.Clear();

            double blankReturn = expectedreturn / 100;
            double carryover=0;
            double interestOf = 0;
            double finalpercentage = 0;
            double notinvestedValueOverYears = initialinvestment;
            double celkem=0;
            

            for (int i = 0; i < yearsinvestment-1; i++)
            {
                if (i == 0)
                {
                    carryover += initialinvestment;
                    carryover+=(initialinvestment*blankReturn);
                    carryover += contributionsinput;

                    //interestOf = carryover * blankReturn;
                    //carryover += interestOf;
                    //carryover += contributionsinput;
                    


                    investedValues.Add(initialinvestment);
                    notInvestedValues.Add(initialinvestment);

                    notinvestedValueOverYears += contributionsinput;

                    notInvestedValues.Add(notinvestedValueOverYears);
                    investedValues.Add(carryover);
                    
                }
                if (i == yearsinvestment-1)
                {
                    carryover += carryover * blankReturn;
                    carryover += contributionsinput;
                    carryover+=(contributionsinput*blankReturn);

                    notInvestedValues.Add(notinvestedValueOverYears);
                    investedValues.Add(carryover);

                }
                else {
                    carryover += carryover * blankReturn;
                    carryover += contributionsinput;
                    notinvestedValueOverYears += contributionsinput;

                    //carryover += contributionsinput;
                    
                    //interestOf = carryover * blankReturn;
                    //carryover += interestOf;
                    notInvestedValues.Add(notinvestedValueOverYears);
                    investedValues.Add(carryover);
                    

                }
                
                
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
