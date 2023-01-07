using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinancialPortal.DatabasePages
{
    /// <summary>
    /// Interakční logika pro MovePage.xaml
    /// </summary>
    public partial class MovePage : MetroWindow
    {
        //moves money between accounts
        public MovePage()
        {
            InitializeComponent();
            
        }

        private void comboboxmove_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            movefrom.Text = comboboxmove.SelectedItem.ToString();
        }


        private void ComboBox_MoveToSelection(object sender, SelectionChangedEventArgs e)
        {
            moveto.Text = comboMoveTo.SelectedItem.ToString();
        }


        private void MoveButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
