using System;
namespace LABA5SARBAIZAD1
{
    class Fraction
    {
        private int first;
        private double second;

        public void Read()
        {
            Console.WriteLine("Введите целую часть числа: ");
            first = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите дробную часть числа: ");
            second = double.Parse(Console.ReadLine());
            if (second < 0)
            {
                Console.WriteLine("Дробная часть должна быть больше нуля...");
                second = -second;
            }
        }

        public void Display()
        {
            Console.WriteLine($"Текущее значение {first}.{second}");
        }

        public void Multiply()
        {
            double divider = Math.Pow(10, second.ToString().Length);
            double tail = second / divider;
            double number = Math.Abs(first) + tail;
            if (first < 0)
            {
                number = -number;
            }
            Console.WriteLine("Введите множитель: ");
            int multiplier = int.Parse(Console.ReadLine());
            double answer = number * multiplier;
            first = (int)answer;
            double newTail = Math.Abs(answer - first) * divider;
            second = (int)Math.Round(newTail);

        }
        class Program
        {
            static void Main(string[] args)
            {
                Fraction fraction = new Fraction();
                fraction.Read();
                fraction.Multiply();
                Console.WriteLine("После умножения: ");
                fraction.Display();
                
            }
        }
    }
    
}