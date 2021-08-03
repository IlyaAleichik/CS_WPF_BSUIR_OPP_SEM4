using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab13
{
    class Integral
    {
    
        public double a, b;
        public int m;// m количество шагов
        public Integral(double ina, double inb, int inm)
        {
            if (ina < inb) { a = ina; b = inb; }
            else { b = ina; a = inb; }
            m = inm;
        }
        private double sif1(double x)//подинтегральная функция
        {
            return (double)(Math.Sin(x));
        }
        public double trapec(Slider sl,ProgressBar pr, Integral I)//Вычисляет частную сумму по методу трапеций
        {
            int c = 0;
            double x = I.a, sum = 0, e = 0.01;// деления всего промежутка интегрирования на отрезки одинаковой длины e
            for (int i = 1; i <= I.b; i++)
            {
                x += e; //
                sum += sif1(x);
                pr.Value = 100 * c++ / (int)sl.Value; 
   
            }
            //   sum += SubIntegralFun.sif1(x);
            return Math.Round(sum);
        }
    }
}
