using System;
using System.Collections.Generic;

namespace Task1_3
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Заполнение ручками
            Node children13 = new Node(null, "text");
            
            Node children10 = new Node(new List<Node>{children13}, "text");
            Node children11 = new Node(null, "text");
            Node children12 = new Node(null, "text");

        
            Node children4 = new Node(new List<Node> {children10, children12}, "text");
            Node children5 = new Node(new List<Node> {children11}, "text");
            Node children6 = new Node(null, "text");
            Node children7 = new Node(null, "text");
            Node children8 = new Node(null, "text");
            Node children9 = new Node(null, "text");
            
            Node children1 = new Node(new List<Node> {children4, children5}, "text");
            Node children2 = new Node(new List<Node> {children6, children7, children8}, "text");
            Node children3 = new Node(new List<Node> {children9}, "text");
            
            Node head = new Node(new List<Node> {children1, children2, children3}, "head");
            
            // Ловим все исключения(
            try
            {
                head.PrintTree();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}