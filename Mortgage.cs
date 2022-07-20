using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class Mortgage:INotifyPropertyChanged
    {
        public double Interests { get; set; }
        public double MonthlyPayment { get; set; }
        public double Totalypaid { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        ChartValues<double> Totalypaidchart { get; set; }
        ChartValues<double> LoanAmountChart { get; set; }
        ChartValues<double> InterestChart { get; set; }

        public Mortgage()
        {
            Totalypaidchart = new ChartValues<double>();
            LoanAmountChart = new ChartValues<double>();
            InterestChart = new ChartValues<double>();
        }


        public void Change(string change){
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(change));
            }
        }
        public void Calculate(double loanamount, double interestrate, double interval, double years)
        {
            https://www.wikihow.com/Calculate-Mortgage-Payments
            try {
            Totalypaidchart.Clear();
            InterestChart.Clear();
            LoanAmountChart.Clear();

            interestrate = (interestrate/ 100) / 12;
            years *= 12;
            LoanAmountChart.Add(loanamount);


            double total = 1 + interestrate;
            
            double upperformula = interestrate * Math.Pow(total, years);
            double lowerformula = Math.Pow(total, years) - 1;
            double subtotal = upperformula / lowerformula;
            double final = loanamount * subtotal;
            

            if (interval == 12)
            {
                final *= 12;
                Totalypaid = final * (years/12);
                Totalypaid = Math.Round(Totalypaid, 2);
                final =Math.Round(final,2);
                MonthlyPayment= final;

                
                Totalypaidchart.Add(Totalypaid);

                Change("MonthlyPayment");
                
                Change("Totalypaid");
            }
            if (interval == 3)
            {
                final *= 3;
                Totalypaid = (final * 4) * (years / 12);
                Totalypaid = Math.Round(Totalypaid,2);
                final =Math.Round(final, 2);
                MonthlyPayment = final;
                
                
                Totalypaidchart.Add(Totalypaid);

                Change("MonthlyPayment");
                Change("Totalypaid");

            }
            if(interval == 6)
            {
                final *= 6;
                Totalypaid = (final * 2) * (years / 12);
                Totalypaid = Math.Round(Totalypaid, 2);
                final =Math.Round(final, 2);
                MonthlyPayment = final;

                
                Totalypaidchart.Add(Totalypaid);

                Change("MonthlyPayment");             
                Change("Totalypaid");
            }
            if (interval == 1)
            {
                Totalypaid = (final * 12) * (years / 12);
                Totalypaid = Math.Round(Totalypaid, 2);
                final =Math.Round(final, 2);

                
                Totalypaidchart.Add(Totalypaid);

                MonthlyPayment = final;
                Change("MonthlyPayment");
                Change("Totalypaid");

            }
                Interests = Totalypaid - loanamount;

                
                InterestChart.Add(Interests);

                AddingtoChart();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
        public void AddingtoChart()
        {
            Chart.SeriesCollectionPieChart.Clear();
            Chart.SeriesCollectionPieChart.Add(new PieSeries
            {
                Title="Totaly paid",
                Values = Totalypaidchart,
            }) ;
            Chart.SeriesCollectionPieChart.Add(new PieSeries
            {
                Title = "Loan amount",
                Values = LoanAmountChart,
            });
            Chart.SeriesCollectionPieChart.Add(new PieSeries
            {
                Title = "Interests",
                Values = InterestChart,
            });


        }
    }
}
