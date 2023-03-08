﻿using FinancialPortal.Accounts;
using FinancialPortal.DatabasePages;
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

namespace FinancialPortal
{
    /// <summary>
    /// Interakční logika pro TitleSetup.xaml
    /// </summary>
    public partial class TitleSetup : Window
    {
        public TitleSetup()
        {
            InitializeComponent();
        }
        bool hiddenUser=false;
        bool hiddenAccount = false;
        private void Setup_Click(object sender, RoutedEventArgs e)
        {
            if ((hiddenAccount == true) && (hiddenUser == true))
            {
                this.Close();
                MainWindow main = new MainWindow();
                main.Show();

            }
            else
            {
                MessageBox.Show("User or Account is not setted up");
            }
            
        }

        private void UserAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUser user = new AddUser();
            user.Show();
            user.Closed += (s, args) => hideUserButton();
        }
        void hideUserButton()
        {
            if (Controller.UserListObservable.Count > 0)
            {
                userAddButton.Visibility = Visibility.Collapsed;
                usertext.Visibility = Visibility.Visible;
                hiddenUser = true;
            }
            
        }
        void hideAccountButton()
        {
            if(Controller.AccountListObservable.Count > 0)
            {
                accountAdd.Visibility = Visibility.Collapsed;
                accounttext.Visibility = Visibility.Visible;
                hiddenAccount = true;
            }
            
        }

        private void AccountAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount acc = new CreateAccount();
            acc.Show();
            acc.Closed += (s, args) => hideAccountButton();
        }
    }
}
