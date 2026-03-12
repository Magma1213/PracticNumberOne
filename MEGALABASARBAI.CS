using System;



public class Program

{

public static void Main()

{

Console.WriteLine("ПОЯВЛЕНИЕ МЕГАРЫЦАРЯ");

Mega_Knight mk = new Mega_Knight

{

Sound = "МЕГАНАААЙТ!",

Cost = 7,

Type = "Ближний бой/Сплэш",

Name = "Мега-Рыцарь",

};



mk.Spawn();

mk.HaveDamage();

mk.MakeSound();

mk.MakeCost();

mk.MakeType();

mk.MakeName();



Console.WriteLine("\nПРОВЕРКА");


Clash_Royale deck = new Mega_Knight

{

Name = "Стандартная карта",

Sound = "Стандартный звук",

Type = "-",

Cost = 0

};


deck.MakeName();

deck.MakeSound();

}

}



class Clash_Royale

{

public string Sound { get; set; } = "";

public int Cost { get; set; }

public string Type { get; set; } = "";

public string Name { get; set; } = "";


public void Spawn()

{

Console.WriteLine("Карта появляется на арене");

}

public void HaveDamage()

{

Console.WriteLine("Карта наносит урон юнитам противника");

}


public void MakeSound()

{

Console.WriteLine("Карта издает звук: " + Sound);

}

public void MakeCost()

{

Console.WriteLine("Стоимость карты: " + Cost);

}


public virtual void MakeType()

{

Console.WriteLine("Тип атаки: " + Type);

}

public virtual void MakeName()

{

Console.WriteLine("Карта называется: " + Name);

}

}


class Mega_Knight : Clash_Royale

{

public string Splash { get; set; } = "Небольшая сплеш атака";

public string Evo { get; set; } = "Есть эволюция";


public override void MakeType()

{

Console.WriteLine("Мега рыцарь атакует с помощью прыжка, а его тип атаки: " + Type + ". Особенность: " + Splash);

}

public override void MakeName()

{

Console.WriteLine("Карта называется: " + Name + ". " + Evo);

}


public new void MakeSound()

{

Console.WriteLine("Звук: МЕГАНАААЙТ");

}

public new void MakeCost()

{

Console.WriteLine("Стоимость карты: 7");

}

}