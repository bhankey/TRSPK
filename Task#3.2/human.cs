using System;

namespace Humans {
  public class Man {

    protected string name; // field поле
    protected int age;

    public string Name // property свойство
    {
      get { return name; }
      set { SetName(value); }
    }  // protected может использоваться наследниками
    
    public int Age  
      {
        get; // read
        set; // write
      } = 16;

    public void SetName( string n ) { // method
      if ( n != "" ) name = n;
      else {
        name = "John Doe";
        Console.WriteLine("Имя не должно быть пустым. Пусть будет "+Name+".");
      }
    } // метод SetName

    virtual public void SetAge( int a ) { // virtual может быть переписана при наследовании
      Age = a;
    }

    virtual public string Show () { // virtual может быть переписана при наследовании
      return "Человек, {"+Name+"}, {"+Age+"}" ;
    }

    public void Print () {
      Console.WriteLine( Show() );
    }
  }

  public class Teenager : Man {

    string school;
    
    public string School {
      get { return school; }
      set { SetSchool(value); }
    }

    override public void SetAge( int a ) { // override переписываем метод базового класса
      if (a>=13 && a<=19) Age=a;
      else Console.WriteLine("Допустимый возраст тинэйджера - от 13 до 19 лет. Оставлено значение по умолчанию: "+Age+".");
    }

    public void SetSchool( string s ) {
      if (s != "") school = s; else school = "Неважно";
    }

    override public string Show () { // override переписываем метод базового класса
      return "Подросток, {"+Name+"}, {"+Age+"}, Место учебы: {"+School+"}" ;
    }
  }

  public class Worker : Man {

    string placeofwork;
    
    public string PlaceOfWork {
      get { return placeofwork; }
      set { SetPlaceOfWork(value); }
    }

    override public void SetAge( int a ) { // override переписываем метод базового класса
      if (a>=16 && a<=70) Age=a;
      else Console.WriteLine("Допустимый возраст работника - от 16 до 70 лет. Оставлено значение по умолчанию: "+Age+".");
    }

    public void SetPlaceOfWork( string s ) {
      if (s != "") placeofwork = s; else placeofwork = "Неважно"; 
    }

    override public string Show () { // override переписываем метод базового класса
      return "Работник, {"+Name+"}, {"+Age+"}, Место работы: {"+PlaceOfWork+"}" ;
    }
  }
}