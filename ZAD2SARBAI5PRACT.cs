using System;

class Money
{

    public int r5000, r1000, r500, r100, r50, r10, r5, r2, r1; 
    public int k50, k10, k5, k1;                         
    
    public void Read()
    {
        Console.WriteLine("Введите количество купюр и монет (если таких нет, пишите 0):");
        Console.Write("Купюр 5000 руб: "); r5000 = int.Parse(Console.ReadLine());
        Console.Write("Купюр 1000 руб: "); r1000 = int.Parse(Console.ReadLine());
        Console.Write("Купюр 500 руб: ");  r500 = int.Parse(Console.ReadLine());
        Console.Write("Купюр 100 руб: ");  r100 = int.Parse(Console.ReadLine());
        Console.Write("Купюр 50 руб: ");   r50 = int.Parse(Console.ReadLine());
        Console.Write("Монет 10 руб: ");   r10 = int.Parse(Console.ReadLine());
        Console.Write("Монет 5 руб: ");    r5 = int.Parse(Console.ReadLine());
        Console.Write("Монет 2 руб: ");    r2 = int.Parse(Console.ReadLine());
        Console.Write("Монет 1 руб: ");    r1 = int.Parse(Console.ReadLine());
        
        Console.Write("Монет 50 коп: ");   k50 = int.Parse(Console.ReadLine());
        Console.Write("Монет 10 коп: ");   k10 = int.Parse(Console.ReadLine());
        Console.Write("Монет 5 коп: ");    k5 = int.Parse(Console.ReadLine());
        Console.Write("Монет 1 коп: ");    k1 = int.Parse(Console.ReadLine());
    }
    
    public double GetTotalSum()
    {
        double rubles = r5000 * 5000 + r1000 * 1000 + r500 * 500 + r100 * 100 + r50 * 50 + r10 * 10 + r5 * 5 + r2 * 2 + r1;
        double kopecks = k50 * 0.50 + k10 * 0.10 + k5 * 0.05 + k1 * 0.01;
        return rubles + kopecks;
    }
    
    public void UpdateBills(double totalAmount)
    {
        if (totalAmount < 0) totalAmount = 0; 

        int rubles = (int)Math.Floor(totalAmount);
        int kopecks = (int)Math.Round((totalAmount - rubles) * 100);

        r5000 = rubles / 5000; rubles %= 5000;
        r1000 = rubles / 1000; rubles %= 1000;
        r500 = rubles / 500;   rubles %= 500;
        r100 = rubles / 100;   rubles %= 100;
        r50 = rubles / 50;     rubles %= 50;
        r10 = rubles / 10;     rubles %= 10;
        r5 = rubles / 5;       rubles %= 5;
        r2 = rubles / 2;       rubles %= 2;
        r1 = rubles;

        k50 = kopecks / 50; kopecks %= 50;
        k10 = kopecks / 10; kopecks %= 10;
        k5 = kopecks / 5;   kopecks %= 5;
        k1 = kopecks;
    }
    
    public void Display()
    {
        Console.WriteLine($"{GetTotalSum():0.00} руб.");
    }


    public void Add(Money other)
    {
        UpdateBills(this.GetTotalSum() + other.GetTotalSum());
    }


    public void Subtract(Money other)
    {
        UpdateBills(this.GetTotalSum() - other.GetTotalSum());
    }


    public double DivideByMoney(Money other)
    {
        if (other.GetTotalSum() == 0) return 0; 
        return this.GetTotalSum() / other.GetTotalSum();
    }


    public void DivideByFraction(double number)
    {
        if (number != 0) UpdateBills(this.GetTotalSum() / number);
    }


    public void MultiplyByFraction(double number)
    {
        UpdateBills(this.GetTotalSum() * number);
    }


    public void Compare(Money other)
    {
        double sum1 = this.GetTotalSum();
        double sum2 = other.GetTotalSum();

        if (sum1 > sum2) Console.WriteLine("Первая сумма БОЛЬШЕ второй.");
        else if (sum1 < sum2) Console.WriteLine("Первая сумма МЕНЬШЕ второй.");
        else Console.WriteLine("Суммы РАВНЫ.");
    }
}


class Program
{
    static void Main()
    {
        Money m1 = new Money();
        Money m2 = new Money();

        Console.WriteLine("--- ВВОД ПЕРВОЙ СУММЫ ---");
        m1.Read(); 

        Console.WriteLine("\n--- ВВОД ВТОРОЙ СУММЫ ---");
        m2.Read(); 
        
        Console.WriteLine("\n=== ИСХОДНЫЕ ДАННЫЕ ===");
        Console.Write("Сумма 1: "); m1.Display();
        Console.Write("Сумма 2: "); m2.Display();

        Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ВСЕХ ОПЕРАЦИЙ ===");


        Console.WriteLine("\n1. Сравниваем суммы:");
        m1.Compare(m2);
        
        Console.WriteLine("\n2. Деление первой суммы на вторую:");
        double divisionResult = m1.DivideByMoney(m2);
        Console.WriteLine($"Результат: в {divisionResult:0.00} раз(а)");
        
        Console.WriteLine("\n3. Делим первую сумму на 2,5:");
        m1.DivideByFraction(2.5);
        m1.Display();
        
        Console.WriteLine("\n4. Умножаем первую сумму на 1,5:");
        m1.MultiplyByFraction(1.5);
        m1.Display();
        
        Console.WriteLine("\n5. Вычитаем из первой суммы вторую:");
        m1.Subtract(m2);
        m1.Display();
        
        Console.WriteLine("\n6. Прибавляем ко первой сумме вторую:");
        m1.Add(m2);
        m1.Display();

        Console.WriteLine("\nНажмите любую кнопку для выхода.");
        Console.ReadKey();
    }
}