using System;
using System.Collections.Generic;

class Program {
  public class stringList {
    string [] stringArray;
    int len;

    public stringList (int g) {
      this.len = g;
      this.stringArray = new string[g];
      for (int i = 0; i < this.len; i++) stringArray[i] = "(empty)"; 
    }
    
    public int Insert (string elem) {
      
      int i;

      for (i = 0; i < len && stringArray[i] != "(empty)"; i++);

      if (i == len) return 0;
      
      stringArray[i] = elem;

      return 1;
    }
    
    public void Delete (int num) {
      
      if (num >= len) return;

      stringArray[num] = "(empty)";
    }

    public int Search (string elem) {

      for (int i = 0; i < len; i++) {
        if (stringArray[i] == elem) return 1;
      }
      
      return 0;
    }
    public void Update (int num, string elem) {
      
      if (num >= len) return;
      
      stringArray[num] = elem;
    
    } 
    public string GetAt (int num) {
    
      if (num >= len) return "Fail";
    
      return stringArray[num];
    }
    public void Print () {
      for (int i = 0; i < len; i++) {
        Console.WriteLine(stringArray[i]);
      }
    }
  }
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");
    var a = new stringList (25);

    a.Insert ("test");
    a.Insert ("test 2");
    a.Insert ("test 3");
    a.Print ();
  }
}