using System;
using System.Windows;
namespace La10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double Min { get; set; }
        private double Max { get; set; }
        private double F(double x)
        {
            double res = 0;  
            if (radBtn1.IsChecked == true)
            {
                res = Math.Cos(x);
            }
            if (radBtn2.IsChecked == true)
            {
                res = Math.Sin(x);
            }
            if (radBtn3.IsChecked == true)
            {
                res = Math.Tan(x);
            }
            return res;
        }

        private double Fun(double x, double y, double z)
        {
            double value = 0;
            if (x*y > 0)
            {
                value =  Math.Pow(F(x) + y, 2) - Math.Sqrt(F(x) * y);
            }
            if (x*y < 0)
            {
                 value = Math.Pow(F(x) + y, 2) - Math.Abs(Math.Sqrt(F(x) * y));
            }
            if (x*y == 0)
            {
                 value = Math.Pow(F(x) + y, 2) + 1;
            }
            return value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double res = Fun(Double.Parse(txtX.Text), Double.Parse(txtY.Text), Double.Parse(txtZ.Text));



            if (ch1.IsChecked == true)
            {
                Min = res;
                if(Max != 0)
                {
                    Min = Math.Min(Min, Max);
                }
            }
            else if (ch2.IsChecked == true)
            {
           
                Max = res;
                if (Min != 0)
                {
                    Max = Math.Max(Min, Max);
                }
            }
            if (ch1.IsChecked == true && ch2.IsChecked == true)
            {
                Max = Math.Max(Min,Max);
                Min = Math.Min(Min,Max);
            }

 
            textResult.Text = res.ToString() + "\n Min: " + Min.ToString() +"\n Max: "+ Max.ToString();

        }
    }
}
