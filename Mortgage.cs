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
        
        public double MonthlyPayment { get; set; }
        public double Totalypaid { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Change(string change){
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(change));
            }
        }
        public void Calculate(double loanamount, double interestrate, double interval, double years)
        {
            Console.WriteLine("Zadejte co si chcete půjčit:");
            double zaklad = double.Parse(Console.ReadLine());
            Console.WriteLine("Zadjete úrok:");
            double urok = ((double.Parse(Console.ReadLine()) / 100) / 12);
            Console.WriteLine("Počet let:");
            double pocetlet = double.Parse(Console.ReadLine()) * 12;


            Console.WriteLine("Kolik si chcete půjčit:" + zaklad);
            Console.WriteLine("úrok:" + urok);
            Console.WriteLine("Počet měsíců:" + pocetlet);
            double mezi = 1 + urok;

            double horni = urok * Math.Pow(mezi, pocetlet);
            double spodni = Math.Pow(mezi, pocetlet) - 1;
            double mezisoucet = horni / spodni;
            double vysledek = zaklad * mezisoucet;
            Console.WriteLine(horni);
            Console.WriteLine(spodni);
            Console.WriteLine(mezisoucet);
            Console.WriteLine("výsledek měsíční" + vysledek);
            Console.WriteLine("výsledek půlroční" + (vysledek * 6));
            Console.WriteLine("výsledek roční" + (vysledek * 12));
            Console.WriteLine("Výsledek kvartální" + (vysledek * 3));
            Console.ReadKey();

        }
    }
}
