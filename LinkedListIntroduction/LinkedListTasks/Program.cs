using System.Diagnostics;
using LinkedListIntroduction.Lib;

namespace LinkedListTasks
{
    class Program
    {
        public static void Main(string[] args)
        {
            
        }

        public static void Q3()
        {
            IntegerLinkedList linkedList = new IntegerLinkedList();
            linkedList.Append(5);
            linkedList.Append(7);
            linkedList.Append(9);
            Console.WriteLine(linkedList);
            linkedList.Delete(5);
            Console.WriteLine(linkedList);
        }
    }
}