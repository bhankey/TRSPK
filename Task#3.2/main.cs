using Humans;

class Program {
  
  public static void Main (string[] args) {
    
    Man[] m = new Man[3]; // создаем массив элементов базового класса как универсальный контейнер для хранения любых из 3 классов Man, Teenager, Worker

    m[0] = new Man();

    m[0].SetAge(50);
    m[0].SetName("Oleg Ivanovich");

    Teenager t = new Teenager(); // создаем объект класса Teenager, в котором задаем нужные нам параметры и переопределяем методы

    t.SetName("Vasya");
    t.SetAge(14);
    t.SetSchool("School №55");

    m[1] = t; // переменной базового класса присваиваем значения производного класса

    Worker w = new Worker();

    w.SetAge(33);
    w.SetName("Michael Jackson");
    w.SetPlaceOfWork("Show Business");

    m[2] = w;

    for( int i=0; i<3; i++ ) {
      //Console.WriteLine(m[i].Show());
      m[i].Print();
    }

  }
}