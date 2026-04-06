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

namespace SarbaiLaba8
{
    public partial class MainWindow : Window
    {
        private Stack<string> inventory = new Stack<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string input = InputTextBox.Text.Trim();
                if (string.IsNullOrEmpty(input)) return; 

                string[] parts = input.Split(new[] { ' ' }, 2);
                string command = parts[0].ToLower(); 

                if (command == "add" && parts.Length == 2)
                {
                    inventory.Push(parts[1]);
                    AddHistory($"Добавлено: {parts[1]}");
                }
                else if (command == "use")
                {
                    if (inventory.Count > 0)
                    {
                        string item = inventory.Pop();
                        AddHistory($"Использовано: {item}");
                    }
                    else
                    {
                        AddHistory("Ошибка: Рюкзак пуст!");
                    }
                }
                else if (command == "top")
                {
                    if (inventory.Count > 0)
                    {
                        string item = inventory.Peek();
                        AddHistory($"Следующим будет: {item}");
                    }
                    else
                    {
                        AddHistory("Ошибка: Рюкзак пуст!");
                    }
                }
                else if (command == "clear")
                {
                    inventory.Clear();
                    AddHistory("Рюкзак полностью очищен.");
                }
                else
                {
                    AddHistory($"Неизвестная команда: {input}");
                }

                UpdateState();
                InputTextBox.Clear();
            }
        }

        private void UpdateState()
        {
            StateListBox.Items.Clear(); 
            foreach (string item in inventory.ToArray())
            {
                StateListBox.Items.Add(item);
            }
        }

        private void AddHistory(string message)
        {
            HistoryListBox.Items.Insert(0, message);
        }
    }
}