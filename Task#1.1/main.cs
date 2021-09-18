using System;
using System.Collections.Generic;

class Program {
  public class stringList
  {
    string[] stringArray;
    int len;

    const int capacity = 100;

    public stringList()
    {
      len = 0;
      stringArray = new string[capacity];
    }

    public int Insert(string elem)
    {
      if (len >= 100)
      {
        Console.WriteLine("Can't insert one more element");
        
        return 1;
      }

      stringArray[len] = elem;
      len++;

      return 0;
    }

    public void Delete (int index) {

      if (index >= len)
      {
        Console.WriteLine("Can't delete element with this index");
        
        return;
      }
      
      for (int i = index; i < len - 1; ++i)
      {
        stringArray[i] = stringArray[i + 1];
      }
    }

    public int Search(string elem)
    {
      for (int i = 0; i < len; i++)
        if (stringArray[i] == elem)
        {
          Console.WriteLine("Found string \"" + stringArray[i] + "\" at position " + i);
          return i;
        }

      Console.WriteLine("String \"" + elem + "\" not found!");
      return -1;
    }

    public void Update(int index, string elem)
    {
      if (index >= len)
      {
        return;
      }
      
      stringArray[index] = elem;
    }

    public string GetAt (int index)
    {
      if (index >= len)
      {
        Console.WriteLine("out of bounds");
        
        return "";
      }

      return stringArray[index];
    }

    public void PrintAt (int g) {
      Console.WriteLine ("#"+ g +": " + GetAt(g));
    }

    public void Print () {
      for (int i = 0; i < this.len; i++)
      {
        PrintAt(i);
      }
    }
  }
  
  
  public static void Main (string[] args) {
    
    var a = new stringList ();

    a.Insert ("test");
    a.Insert ("test 2");
    a.Insert ("test 3");
    a.Insert ("test 4");

    a.Delete (2);



    a.Print();

    a.Search ("test");
    a.Search ("test 3");

  }
}