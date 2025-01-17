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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPLay_Click(object sender, RoutedEventArgs e)
        {
            double S;
            Integral MyIntegral = new Integral(0, 2 * Math.PI, 400);
            textResult.Text = MyIntegral.trapec(slSLider, barProgress,MyIntegral).ToString();
        }
    }
}
