namespace Task1_2
{

    
    public class DifferenceMatter
    {
        public const int i = 5; // Константа должна инициализироваться при определении. Значения должны быть известны при компиляции

        // const Empty s = new Empty(); // Не можем создать из-за того, что значение не может быть расчитано во время  компиляции

        // const int ii;  // Не можем создать, т.к нет инициализации
        public readonly int ii = 5; // можно инициализировать при их объявлении либо на уровне класса, либо инициилизировать и изменять в конструкторе
        
        public readonly Empty s = new Empty(); // Можно т.к значение определиться во время выполнения

        public int ReturnConstant()
        {
            const int i = 10; // Константа может быть объявлена в методе
            
            return i;
        }
    }
    
    public class Empty
    {

        public readonly int i; // Можно не инициализировать при определении
        public Empty()
        {
            i = 5; // А инициализировать в конструкторе
        }

        public int ReturnReadOnly()
        {
            // i = 10; // Не можем изменить
            
            return i;
        }
        
    }
}