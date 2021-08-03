using System;
using System.Drawing;
using System.Windows;

namespace WPFLabsBSUIR_OPP_SEM4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawPolygonPointF();
        }

        public void DrawPolygonPointF()
        {

            int n = 4;               // число вершин
            double R = 20, r = 100;   // радиусы
            double alpha = 0;        // поворот
            double x0 = 100, y0 = 100; // центр

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(pictureBox.Width, pictureBox.Height);     
            Graphics graphics = Graphics.FromImage(bmp);

            SolidBrush blueBrush = new SolidBrush(System.Drawing.Color.Blue);

            PointF[] points = new PointF[2 * n + 1];
            double a = alpha, da = Math.PI / n, l;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                a += da;
            }


            // Draw polygon curve to screen.
            graphics.FillPolygon(blueBrush, points);
            pictureBox.Image = bmp;
        }
        private void Draw()
        {

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red);
            graphics.DrawLine(pen,10,50,100,200);
            pictureBox.Image = bmp;

        }
    }
}
