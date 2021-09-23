using System;

namespace Humans {
  public class Man {

    protected string Name = "John Doe"; // protected может использоваться наследниками
    protected int Age = 16;

    public void SetName( string n ) {
      if ( n != "" ) Name = n;
      else Console.WriteLine("Имя не должно быть пустым. Пусть будет "+Name+".");
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

    string School = "Неважно";

    override public void SetAge( int a ) { // override переписываем метод базового класса
      if (a>=13 && a<=19) Age=a;
      else Console.WriteLine("Допустимый возраст тинэйджера - от 13 до 19 лет. Оставлено значение по умолчанию: "+Age+".");
    }

    public void SetSchool( string s ) {
      School = s;
    }

    override public string Show () { // override переписываем метод базового класса
      return "Подросток, {"+Name+"}, {"+Age+"}, Место учебы: {"+School+"}" ;
    }
  }

  public class Worker : Man {

    string PlaceOfWork = "Неважно";

    override public void SetAge( int a ) { // override переписываем метод базового класса
      if (a>=16 && a<=70) Age=a;
      else Console.WriteLine("Допустимый возраст работника - от 16 до 70 лет. Оставлено значение по умолчанию: "+Age+".");
    }

    public void SetPlaceOfWork( string s ) {
      PlaceOfWork = s;
    }

    override public string Show () { // override переписываем метод базового класса
      return "Работник, {"+Name+"}, {"+Age+"}, Место работы: {"+PlaceOfWork+"}" ;
    }
  }
}