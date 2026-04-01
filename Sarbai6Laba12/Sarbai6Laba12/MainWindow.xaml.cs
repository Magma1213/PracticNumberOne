using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sarbai6Laba12
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void CheckNumber_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(InputLab2.Text);
                if (num > 0) ResultLab2.Text = "Положительное";
                else if (num < 0) ResultLab2.Text = "Отрицательное";
                else ResultLab2.Text = "Ноль";
            }
            catch { ResultLab2.Text = "Ошибка: введите число!"; }
        }


        private void CountArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] parts = InputLab3.Text.Split(' ');
                int pos = 0, neg = 0, zero = 0;

                foreach (string part in parts)
                {
                    if (string.IsNullOrWhiteSpace(part)) continue;
                    double num = Convert.ToDouble(part);
                    if (num > 0) pos++;
                    else if (num < 0) neg++;
                    else zero++;
                }
                ResultLab3.Text = $"Плюсов: {pos}, Минусов: {neg}, Нулей: {zero}";
            }
            catch { ResultLab3.Text = "Ошибка: вводите числа через пробел!"; }
        }


        private void Matrix_Click(object sender, RoutedEventArgs e)
        {

            Random rnd = new Random();
            int[,] matrix = new int[3, 3];
            string orig = "Исходная:\n";
            string trans = "Перевернутая:\n";


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = rnd.Next(-10, 11);
                    orig += matrix[i, j] + "\t";
                }
                orig += "\n";
            }


            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    trans += matrix[i, j] + "\t";
                }
                trans += "\n";
            }

            ResultLab4.Text = orig + "\n" + trans;
        }

        private void CalcCost_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PhoneCall call = new PhoneCall();
                call.Minutes = Convert.ToInt32(InputMins.Text);
                call.CostPerMin = Convert.ToDouble(InputCost.Text);

                ResultLab5.Text = $"К оплате: {call.GetTotalCost()} руб.";
            }
            catch { ResultLab5.Text = "Ошибка: проверьте ввод!"; }
        }
    }


    public class PhoneCall
    {
        public int Minutes { get; set; }
        public double CostPerMin { get; set; }

        public double GetTotalCost()
        {
            return Minutes * CostPerMin;
        }
    }
}