using System;
using System.Reflection;

class Program
{

  public class NameAttribute : System.Attribute
    {
        public string Description;
        public NameAttribute() { }
        public NameAttribute(string str)
          {
            Description = str;
          }
        public override string ToString()
          {
            return Description;
          }
    }

  public class FirstClass
  {
    [Name(Description = "Свойство №01")]
    public string first {get; set;}

    [Name(Description = "Свойство №02")]
    public string second {get; set;}
    
    [Name(Description = "Свойство №03")]
    public string third {get; set;}

    [Name(Description = "Свойство №04")]
    public string fourth {get; set;}

    [Name(Description = "Свойство №05")]
    public string fifth {get; set;}

    [Name(Description = "Свойство №06")]
    public string sixth {get; set;}

    [Name(Description = "Свойство №07")]
    public string seventh {get; set;}

    [Name(Description = "Свойство №08")]
    public string eighth {get; set;}

    [Name(Description = "Свойство №09")]
    public string nineth {get; set;}

    [Name(Description = "Свойство №10")]
    public string tenth {get; set;}
  }

  static void Main()
    {
      FirstClass fc = new FirstClass();
    
      foreach (PropertyInfo prop in typeof(FirstClass).GetProperties()) 
      // для каждого свойства prop в классе типа FirstClass
        {
        
          foreach (var attribute in prop.GetCustomAttributes(false))
          // для каждого атрибута свойства prop
            {
              Console.WriteLine("{0,10} = {1}",prop.Name, attribute.ToString());
              // выдаем имя свойства prop и его аттрибут(ы)
            }
        
        }
    
    }

}