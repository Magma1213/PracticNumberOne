using System;
public class DynamicContainer<T>
{
    private T[] data;      
    private int size;    
    private int capacity;  
    
    public DynamicContainer(int initialCapacity = 4)
    {
        capacity = initialCapacity;
        data = new T[capacity];
        size = 0;
    }


    public int Count
    {
        get { return size; }
    }
    
    public T this[int index]
    {
        get
        {
            CheckBounds(index); 
            return data[index];
        }
        set
        {
            CheckBounds(index);
            data[index] = value;
        }
    }
    
    public void Add(T item)
    {

        if (size == capacity)
        {
            capacity *= 2;
            T[] newData = new T[capacity];
            Array.Copy(data, newData, size); 
            data = newData;
        }
        
        data[size] = item;
        size++;
    }

 
    public void Insert(int index, T item)
    {
 
        if (index < 0 || index > size)
        {
            throw new ArgumentOutOfRangeException("Индекс вне диапазона! Арена такого не прощает.");
        }

        if (size == capacity)
        {
            capacity *= 2;
            T[] newData = new T[capacity];
            Array.Copy(data, newData, size);
            data = newData;
        }


        for (int i = size; i > index; i--)
        {
            data[i] = data[i - 1];
        }
        
        data[index] = item;
        size++;
    }


    public void RemoveAt(int index)
    {
        CheckBounds(index);


        for (int i = index; i < size - 1; i++)
        {
            data[i] = data[i + 1];
        }
        size--;
    }


    private void CheckBounds(int index)
    {
        if (index < 0 || index >= size)
        {

            throw new ArgumentOutOfRangeException("Индекс вне допустимого диапазона! Вы вышли за пределы Арены!");
        }
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("--- Тестирование мега-колоды Clash Royale ---");
        
        DynamicContainer<string> myDeck = new DynamicContainer<string>();
        
        for (int i = 0; i < 1000; i++)
        {
            if (i == 0) 
                myDeck.Add("П.Е.К.К.А");
            else if (i == 500) 
                myDeck.Add("Всадник на кабане (Hog Rider)");
            else if (i == 999) 
                myDeck.Add("Бревно (The Log)");
            else 
                myDeck.Add($"Скелетик #{i}"); 
        }


        Console.WriteLine($"Карта [0]: {myDeck[0]}");
        Console.WriteLine($"Карта [500]: {myDeck[500]}");
        Console.WriteLine($"Карта [999]: {myDeck[999]}");
        Console.WriteLine($"Всего карт в хранилище: {myDeck.Count}");

        Console.WriteLine("\n--- Проверка защиты от ошибок ---");
        try
        {
            string missingCard = myDeck[2000]; 
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Отлично! Ошибка поймана корректно:");
            Console.WriteLine(ex.Message);
        }
    }
}