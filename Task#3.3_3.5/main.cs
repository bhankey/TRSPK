using System;

  public class El {
    
    public string name; // доступ понадобится индексеру
    public int val;

    public El ( string s, int n ) { // конструктор El
      name = s;
      val = n;
    }
    
    public override bool Equals(Object obj_to_compare) { 
    // 1 требование индексера Array.IndexOf (метод)
    // virtual method from Object
        
    string name_to_compare = (string) obj_to_compare; // это чтоб сравнить имя 
    return (obj_to_compare != null) && (this.name == name_to_compare);
    }

    public override int GetHashCode() { 
    // 2 требование индексера Array.IndexOf (метод)
      return HashCode.Combine(name, val);
    // создается hashcode имени и значения
    }
  }


class Program {

  public static void SwapInt(ref int a, ref int b) { // static т.к. это функция не принадлежащая какому-то объекту 
  
    // это простой надежный метод обмена через временную переменную
    //int t;

    //t = a;
    //a = b;
    //b = t;

    // это обмен используя кортеж - не требует временной переменной, но есть не во всех версиях C#
    (a,b)=(b,a);
  }

  public static void Main (string[] args) {

    El[] ArrEl = new El[3];

    ArrEl[0] = new El("zero",0); // доступ к элементам массива по обычному индексу
    ArrEl[1] = new El("one",1);
    ArrEl[2] = new El("two",2);
    
    string name_to_find = "zero";
    int index = Array.IndexOf( ArrEl, name_to_find);  // поиск индекса элемента по имени

    Console.WriteLine("При поиске по имени :" + name_to_find);
    Console.WriteLine("функция индекс по имени вернула результат :" + index);

    Console.WriteLine();
    
//-----------------------------------------------------------------------------------
    Console.WriteLine ("Обмен 2 переменных при помощи ref:");
    int a=1111, b=2222;

    Console.WriteLine (a + " , " + b);
    SwapInt (ref a, ref b);
    Console.WriteLine (a + " , " + b);

  }
}