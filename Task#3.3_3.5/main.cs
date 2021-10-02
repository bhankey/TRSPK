using System;




class Program {
  
  public class El {
    public string name; // доступ понадобится индексеру
    public int val;

    public El ( string s, int n ) { // конструктор El
      name = s;
      val = n;
    }
    
    public override int GetHashCode() {
      return HashCode.Combine(name, val);
    }
    
    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return name == ((El)(obj)).name && val == ((El)(obj)).val;
    }
    
  }


  public class ArrEl
  {
    public El[] Array;
    private int _size;
    private int _capacity;
    
    
    public ArrEl(int size)
    {
      Array = new El[size];
      _capacity = size;
      _size = 0;
    }
    
    public El this[int i]
    {
      get => Array[i];
      set => Array[i] = value;
    }

    public El this[string name]
    {
      get
      {
        foreach (var el in Array)
        {
          if (el.name == name)
          {
            return el;
          }
        }

        throw new Exception("No element in array");
      }
      
      set
      {
        for (var i = 0; i < Array.Length; i++)
        {
          if (Array[i].name == name)
          {
            Array[i] = value;
            
            return;
          }
        }
        
        throw new Exception("Can not install not existed value by name");
      }

    }
  }

  public static void SwapInt(ref int a, ref int b) { // static т.к. это функция не принадлежащая какому-то объекту 
    (a,b)=(b,a);
  }

  public static void Main (string[] args)
  {

    var arrEl = new ArrEl(5);

    arrEl[0] = new El("zero",0); // доступ к элементам массива по обычному индексу
    arrEl[1] = new El("one",1);
    arrEl[2] = new El("two",2);

    Console.WriteLine("При поиске по индексу {0}:{1}", arrEl[0].name, arrEl[0].val);
    
    Console.WriteLine("При поиске по имени {0}:{1}", arrEl["one"].name, arrEl["one"].val);

    Console.WriteLine();
    
//-----------------------------------------------------------------------------------

    Console.WriteLine ("Обмен 2 переменных при помощи ref:");
    int a=1111, b=2222;

    Console.WriteLine (a + " , " + b);
    SwapInt (ref a, ref b);
    Console.WriteLine (a + " , " + b);

  }
}