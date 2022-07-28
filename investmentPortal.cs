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
        public investmentPortal()//declaring chartvalues collection
        {
            investedValues = new ChartValues<double>();
            notInvestedValues = new ChartValues<double>();
        }

        public void Onetime(double initialinvest, double yearsinvestment, double expectedreturn)//calculating according to onetime deposit
        {
            notInvestedValues.Clear();//clearing charts
            investedValues.Clear();
            double blankReturn;
            blankReturn = expectedreturn / 100;//delcaring variables
            double finalpercentage = 0;


            double invested = 0;
            for (int i = 0; i < yearsinvestment; i++)
            {
                if (i == 0)
                {
                    invested = initialinvest + (initialinvest * blankReturn);
                    notInvestedValues.Add(0);//adding first number
                    investedValues.Add(0);

                    investedValues.Add(invested);
                    notInvestedValues.Add(initialinvest);
                }
                else
                {
                    invested += (invested * blankReturn);
                    investedValues.Add(invested);
                    notInvestedValues.Add(initialinvest);
                }


            }
            finalpercentage = (invested / initialinvest) - 1;//rounding and calculation of the percantage yield
            finalpercentage = finalpercentage * 100;
            finalpercentage = Math.Round(finalpercentage, 2);

            FinalAmount = Math.Round(invested, 2);
            Return = finalpercentage.ToString() + "%";

            Change("FinalAmount");
            Change("Return");

            AddingToChart();


        }
        public void MonthlyContribution(double initialinvestment, double yearsinvestment, double expectedreturn, double contributionsinput)
        {
            Yearlycontribution(initialinvestment, yearsinvestment, expectedreturn, (contributionsinput * 12));//it is yearly distirbution but it is *12
        }
        public void Yearlycontribution(double initialinvestment, double yearsinvestment, double expectedreturn, double contributionsinput)
        {
            notInvestedValues.Clear();//clearing collections
            investedValues.Clear();

            double blankReturn = expectedreturn / 100;//declaring variables
            double carryover = 0;
            double interestOf = 0;
            double finalpercentage = 0;
            double notinvestedValueOverYears = initialinvestment;
            double celkem = 0;


            for (int i = 0; i < yearsinvestment - 1; i++)
            {
                if (i == 0)
                {
                    carryover += initialinvestment;
                    carryover += (initialinvestment * blankReturn);
                    carryover += contributionsinput;

                    //interestOf = carryover * blankReturn;
                    //carryover += interestOf;
                    //carryover += contributionsinput;



                    investedValues.Add(initialinvestment);//adding first number
                    notInvestedValues.Add(initialinvestment);

                    notinvestedValueOverYears += contributionsinput;

                    notInvestedValues.Add(Math.Round(notinvestedValueOverYears,2));//adding data to collection
                    investedValues.Add(Math.Round(carryover,2));

                }
                if (i == yearsinvestment - 1)
                {
                    carryover += carryover * blankReturn;
                    carryover += contributionsinput;
                    carryover += (contributionsinput * blankReturn);

                    notInvestedValues.Add(Math.Round(notinvestedValueOverYears,2));//adding data to collection
                    investedValues.Add(Math.Round(carryover,2));

                }
                else
                {
                    carryover += carryover * blankReturn;
                    carryover += contributionsinput;
                    notinvestedValueOverYears += contributionsinput;

                    //carryover += contributionsinput;

                    //interestOf = carryover * blankReturn;
                    //carryover += interestOf;
                    notInvestedValues.Add(Math.Round(notinvestedValueOverYears,2));
                    investedValues.Add(Math.Round(carryover,2));


                }


            }

            FinalAmount = Math.Round(carryover, 2);

            finalpercentage = (carryover / initialinvestment) - 1;
            finalpercentage = finalpercentage * 100;//rounding and calcutaction of the percantage yield
            finalpercentage = Math.Round(finalpercentage, 2);


            Return = finalpercentage.ToString() + "%";



            Change("FinalAmount");
            Change("Return");
            AddingToChart();

        }
        public void AddingToChart()
        {
            Chart.SeriesCollection.Clear();//clearing of the chart
            Chart.SeriesCollection.Add(new LineSeries//adding data to the seriescollection
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

        public void Change(string change)//changing properties
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(change));
            }
        }
    }
}
