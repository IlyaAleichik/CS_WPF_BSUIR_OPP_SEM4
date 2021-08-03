using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab11
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValidateTextBox validate = new ValidateTextBox(listBox,textBoxXStart,textBoxXfinish,textBoxHStep,textBoxNSumm);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class Variable
    {
        public double X { get; set; }
        public double Sum { get; set; }
        public double Y { get; set; }
    }

    public class ValidateTextBox : Window
    {
        double x1, x2, h;
        int n;
        ListBox listBox;

        public ValidateTextBox(ListBox list,TextBox textX1, TextBox textX2, TextBox textH, TextBox textSumm) {
            this.x1 = Double.Parse(textX1.Text);
            this.x2 = Double.Parse(textX2.Text);
            this.h = Double.Parse(textH.Text);
            this.n = Int32.Parse(textSumm.Text);
            this.listBox = list;
            getValid();
        }


        public long getFactorial(long n)
        {
            if (n == 0)
                return 1;
            else
                return n * getFactorial(n - 1);
        }

        private void getValid()
        {
            if(x1 < 0.1 || x1 > 0.3)
            {
                MessageBox.Show("Введите числовое значние от 0.1 до 0.3");
            }
            if (x2 < 0.7 || x2 > 0.9)
            {
                MessageBox.Show("Введите числовое значние от 0.7 до 0.9");
            }
            if (h < 0.1 || h > 0.2)
            {
                MessageBox.Show("Введите числовое значние от 0.1 до 0.2");
            }
            if (n < 5 || n > 20)
            {
                MessageBox.Show("Введите числовое значние от 5 до 20");
            }
            else
            {
                foreach (Variable variable in getSumm()) {
                    listBox.Items.Add("при x= " + variable.X + " Summ =" + variable.Sum + " Точное значение =" + variable.Y);
                }
                listBox.Items.Add("Разработка Алейчика И.Д.");
            }
        }

        public ObservableCollection<Variable> getSumm()
        {
            ObservableCollection<Variable> variables = new ObservableCollection<Variable>();

            double sum = 0, y  = 0;
            for (int k = 0; k < n; k++)
            {          
                sum = (Math.Pow(Math.Log10(3), k)/getFactorial(k)) * Math.Pow(x1, k);
                y = Math.Pow(3, x1) - 1;              
                x1 += h;
                variables.Add(new Variable { X = x1, Sum = sum, Y = y });
                if (x1 == x2) break;
            }

            return variables;
        }
    }

}
