using System;
using System.Collections.Generic;

class Program {
  public class stringList {
    string [] stringArray;
    int len;

    public stringList () {
      this.len = 100;
      this.stringArray = new string[100]; 
    }
    
    public int Insert (string elem) {
      
      int i;

      for (i = 0; i < len; i++) {
        if ( String.IsNullOrEmpty(stringArray[i]) ) break;
      }

      if (i == len) return 0;
      
      stringArray[i] = elem;

      return 1;
    }
    
    public void Delete (int num) {
      
      if (num >= len) return;

      stringArray[num] = String.Empty;
    }

    public int Search (string elem) {

      for (int i = 0; i < len; i++) 
        if (stringArray[i] == elem) {
          Console.WriteLine("Found string \""+elem+"\" at position "+ i);
          return 1;
        }
      
      Console.WriteLine("String \""+elem+"\" not found!");
      return 0;
    }

    public void Update (int num, string elem) {
      
      if (num >= len) return;
      
      stringArray[num] = elem;
    
    }

    public string GetAt (int num) {
    
      if (num >= len) return "Fail";
    
      if (String.IsNullOrEmpty(stringArray[num])) return "no element";

      return stringArray[num];
    }

    public void PrintAt (int g) {
      Console.WriteLine ("#"+ g +": " + this.GetAt (g));
    }

    public void Print () {
        for (int i=0; i<this.len; i++) this.PrintAt(i);
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