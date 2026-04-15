using Microsoft.Win32;
using System.Collections;
using System.Diagnostics;
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
using System.IO;

namespace Laba9Sarbai
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbArraySize.Text, out int size) && size > 0)
            {
                Random rnd = new Random();
                Context.array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    Context.array[i] = rnd.Next(1, 100);
                }
                PrintArray("Сгенерированный массив:");
            }
        }

        private void btnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
            };

            if (opf.ShowDialog() == true)
            {
                Context.array = File.ReadAllText(opf.FileName)
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                PrintArray("Массив из файла:");
            }
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            if (Context.array == null || Context.array.Length == 0) return;

            Context context = new Context();

            if (rbSelection.IsChecked == true)
            {
                context.ContextStrategy = new SelectionSort();
            }
            else if (rbRadix.IsChecked == true)
            {
                context.ContextStrategy = new RadixSort();
            }

            context.ExecuteAlgorithm();
            PrintArray("Отсортированный массив:");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            rtbOutput.Document.Blocks.Clear();
            Context.array = null;
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt"
            };

            if (saveDialog.ShowDialog() == true)
            {
                var text = new TextRange(rtbOutput.Document.ContentStart, rtbOutput.Document.ContentEnd).Text;
                File.WriteAllText(saveDialog.FileName, text);
            }
        }

        private void PrintArray(string title)
        {
            rtbOutput.AppendText(title + "\n" + string.Join(" ", Context.array) + "\n\n");
            rtbOutput.ScrollToEnd();
        }
    }

    public interface IStrategy
    {
        int[] Algorithm(int[] mas, bool flag = true);
    }

    public class Context
    {
        public IStrategy ContextStrategy;
        public static int[] array;

        public Context(IStrategy Strategy)
        {
            this.ContextStrategy = Strategy;
        }

        public Context() { }

        public void ExecuteAlgorithm(bool flag = true)
        {
            ContextStrategy.Algorithm(array, flag);
        }
    }

    public class SelectionSort : IStrategy
    {
        public int[] Algorithm(int[] array, bool flag = true)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    int temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;
                }
            }

            timer.Stop();
            return array;
        }
    }

    public class RadixSort : IStrategy
    {
        public int[] Algorithm(int[] array, bool flag = true)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];
            }

            int length = max.ToString().Length;
            int range = 10;

            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i)
            {
                lists[i] = new ArrayList();
            }

            for (int step = 0; step < length; ++step)
            {
                for (int i = 0; i < array.Length; ++i)
                {
                    int temp = (array[i] % (int)Math.Pow(range, step + 1)) / (int)Math.Pow(range, step);
                    lists[temp].Add(array[i]);
                }

                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        array[k++] = (int)lists[i][j];
                    }
                }

                for (int i = 0; i < range; ++i)
                {
                    lists[i].Clear();
                }
            }

            timer.Stop();
            return array;
        }
    }
}