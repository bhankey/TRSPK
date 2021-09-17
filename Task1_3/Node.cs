using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_3
{
    public class Node
    {
        public Node(List<Node> children, string text)
        {
            Children = children;
            Text = text;
        }
        
        public List<Node> Children;
        
        public string Text;

        readonly string[] _treeSymbols = {"│", "├", "─",  "└"};
        
            // nesting: 0 - последний ребенок, 1 - противоположенно 
        private void _printTree(List<int> nesting)
        {
            // Цикл в котором мы печатаем в зависимости от вложенности
            for (var i = 0; i < nesting.Count; i++)
            {
                // Тут печатаем отступы элементов, которые были перед текущим
                if (i != nesting.Count - 1)
                {
                    switch (nesting[i])
                    {
                        case 0:
                            Console.Write("  ");
                            break;
                        case 1:
                            Console.Write("{0}{1}", _treeSymbols[0], " ");
                            break;
                    }
                }
                // Отступы для текущего элемента
                else
                {
                    switch (nesting[i])
                    {
                        case 0:
                            // Выводим так, чтобы не конкатенировать строки, ибо выделяется новая память и все что из этого исходит
                            Console.Write( "{0}{1}", _treeSymbols[3], _treeSymbols[2]);
                            break;
                        case 1:
                            Console.Write("{0}{1}", _treeSymbols[1], _treeSymbols[2]);
                            break;
                    }
                }
            }

            // Печатаем саму ноду и перенос строки
            Console.Write(Text + "\n");
            
            // Проверочка на то что у ноды нет детей
            if (Children == null)
            {
                return;
            }
            
            // Проходимся по детям ноды и рекурсивно их печатаем
            for (int i = 0; i < Children.Count; i++)
            {
                // Отмечаем последний ли это ребенок или нет
                if (i == Children.Count - 1)
                {
                    nesting.Add(0);
                    Children[i]._printTree(nesting);
                    nesting.RemoveAt(nesting.Count - 1);
                }
                else
                {
                    nesting.Add(1);
                    Children[i]._printTree(nesting);
                    nesting.RemoveAt(nesting.Count - 1);
                }
            }

        }
        
        // Функция чтобы некрасивый вызов кишков
        public void PrintTree()
        {
            var nesting = new List<int>();
            _printTree(nesting);
        }
    }
}