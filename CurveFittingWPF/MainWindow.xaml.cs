using ScottPlot;
using ScottPlot.Plottable;
using System.Collections.Generic;
using System.Windows;

namespace CurveFittingWPF
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

        private void Example1()
        {
            Plot.Plot.Clear();
            var x_array = new double[] { -3, -2, 2, 3, 4 };
            var y_array = new double[] { 9, 4, 4, 9, 16 };

            Plot.Plot.AddScatter(x_array, y_array);
            double[] p = MathNet.Numerics.Fit.Polynomial(x_array, y_array, 2);

            List<double> x_f = new List<double>();
            List<double> y_f = new List<double>();

            for (double i = -3; i < 3; i += 0.1)
            {
                x_f.Add(i);
                y_f.Add(p[0] + p[1] * i + p[2] * i * i);
            }

            Plot.Plot.AddScatter(x_f.ToArray(), y_f.ToArray());

            double a = p[2];
            double b = p[1];
            double c = p[0];

            var min_x = new double[1] { -b / (2 * a) };
            var min_y = new double[1] { (4 * a * c - b * b) / (4 * a) };
            var new_plot = new ScatterPlot(min_x, min_y);
            new_plot.MarkerShape = MarkerShape.openDiamond;
            new_plot.MarkerSize = 20;
            Plot.Plot.Add(new_plot);
            Plot.Plot.AddTooltip($"{min_x[0]}, {min_y[0]}", min_x[0], min_y[0]);
        }

        private void Example2()
        {
            Plot.Plot.Clear();
            var x_array = new double[] { 0.8, 0.9, 1, 1.1, 1.2 };
            var y_array = new double[] { 0.8625, 0.8225, 0.8025, 0.8025, 0.8225 };

            Plot.Plot.AddScatter(x_array, y_array);
            double[] p = MathNet.Numerics.Fit.Polynomial(x_array, y_array, 2);

            List<double> x_f = new List<double>();
            List<double> y_f = new List<double>();

            for (double i = 0.8; i < 1.3; i += 0.01)
            {
                x_f.Add(i);
                y_f.Add(p[0] + p[1] * i + p[2] * i * i);
            }

            Plot.Plot.AddScatter(x_f.ToArray(), y_f.ToArray());

            double a = p[2];
            double b = p[1];
            double c = p[0];

            var min_x = new double[1] { -b / (2 * a) };
            var min_y = new double[1] { (4 * a * c - b * b) / (4 * a) };
            var new_plot = new ScatterPlot(min_x, min_y);
            new_plot.MarkerShape = MarkerShape.openDiamond;
            new_plot.MarkerSize = 20;
            Plot.Plot.Add(new_plot);
            Plot.Plot.AddTooltip($"{min_x[0]}, {min_y[0]}", min_x[0], min_y[0]);
        }

        private void Example1_OnClick(object sender, RoutedEventArgs e)
        {
            Example1();
        }

        private void Example2_OnClick(object sender, RoutedEventArgs e)
        {
            Example2();
        }
    }
}