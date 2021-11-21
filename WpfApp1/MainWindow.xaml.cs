using System;
using System.Windows;
using System.IO;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void b1(object sender, RoutedEventArgs e)
        {
            try 
            {
                double a = Convert.ToDouble(textA.Text);
                double b = Convert.ToDouble(textB.Text);
                double c = Convert.ToDouble(textC.Text);
                double D = (b * b) - (4 * a * c);

                if (D == 0)
                {
                    Console.WriteLine();
                    double x = -b / (2 * a);
                    MessageBox.Show($"D={D}\nx = {x}");
                    Log("=", $"D={D}", $"x = {x}", "");
                }
                else if (D > 0)
                {
                    double x1, x2;
                    x1 = (-b + D) / (2 * a);
                    x2 = (-b - D) / (2 * a);
                    MessageBox.Show($"D={D}\nx1={x1}\nx2={x2}");
                    Log("=", $"D={D}", $"x1={x1}", $"x2={x2}");
                }
                else
                {
                    MessageBox.Show($"D={D}");
                    Log("=", $"D={D}", "", "");
                }
            }
            catch 
            {
                MessageBox.Show($"error");
                Log("=", $"error", "", "");
            }
            
        }
        private void b2(object sender, RoutedEventArgs e)
        {
            textC.Text = "";
            textB.Text = "";
            textA.Text = "";
            Log("Del", "", "", "");
        }
        private void Log(string text, string text1, string text2, string text3) 
        {
            DateTime Time = DateTime.Now;
            using (FileStream fstream = new FileStream($"Logi.txt", FileMode.Append))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes($"Время {Time}, {text}, {text1}, {text2} , {text2}\n");
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
