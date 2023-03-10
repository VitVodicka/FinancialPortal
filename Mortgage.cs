using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        ChartValues<double> InterestChart { get; set; }//declaring new chartValues collection

        public Mortgage()
        {
            Totalypaidchart = new ChartValues<double>();
            LoanAmountChart = new ChartValues<double>();//declaring new chartValues collection
            InterestChart = new ChartValues<double>();
        }

        //Changing properties
        public void Change(string change){
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(change));
            }
        }
        public void Calculate(double loanamount, double interestrate, double interval, double years)
        {//calculation of mortgage payments
            //https://www.wikihow.com/Calculate-Mortgage-Payments
            try {
            Totalypaidchart.Clear();
            InterestChart.Clear();
            LoanAmountChart.Clear();//clearing chart

            interestrate = (interestrate/ 100) / 12;
            years *= 12;
            LoanAmountChart.Add(loanamount);


            double total = 1 + interestrate;
            
            double upperformula = interestrate * Math.Pow(total, years);
            double lowerformula = Math.Pow(total, years) - 1;
            double subtotal = upperformula / lowerformula;
            double final = loanamount * subtotal;
            

            if (interval == 12)//calculating according to monthy payment
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
            if (interval == 3)//calculating according to quartaly payment
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
            if(interval == 6)//calculating according to half yearly payment
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
            if (interval == 1)//calculating according to yearly payment
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
                Console.WriteLine("Error in Mortgage.Calculate:"+ex.Message);
            }



        }
        public void AddingtoChart()
        {//clearing chart and adding values to it
            try { 
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
            catch(Exception e)
            {
                MessageBox.Show("AddingToChart"+e.Message);
            }


        }
    }
}
