﻿using System;
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
using System.Windows.Navigation;

namespace PizzeriaProjekt
{
    /// <summary>
    /// Interaction logic for registerWindow.xaml
    /// </summary>
    public partial class registerWindow : Window
    {
      
        public registerWindow()
        {
            InitializeComponent();

        }
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RulesFrame.Content = new welcomePage();
        }

        private void finishRegister_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loginWindow loginWindow = new loginWindow();
            loginWindow.Show();
        }
    }
}

