using System;
using System.Collections.Generic;
//using System.Collections; 
namespace LAB2
{
    internal class Program
    {
        public static void RandomNum(int num)
        {
            Random random = new Random();

            List<int> numbers = new List<int>();

            Console.WriteLine("Day so ngau nhien:");

            for (int i = 0; i < num; i++)
            {
                int value = random.Next(100);
                numbers.Add(value);
                Console.Write($"{value} ");
                Console.Write(value + " ");
                numbers.Reverse();
            }

            Console.WriteLine("\n\nDay sau khi sap xep tang dan:");

            numbers.Sort();

            foreach (int value in numbers)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.Write("NHap so luong phan tu: ");
            int n = int.Parse(Console.ReadLine());

            if (n > 0)
            {
                RandomNum(n);
            }
            else
            {
                Console.WriteLine("Gia tri nhap phai lon hon so 0.");
            }
        }
    }
}
















































//            Stack mystack = new Stack();
//            mystack.Push(1);
//            mystack.Push(2);
//            mystack.Push(3);
//            mystack.Push(4);
//            var a = mystack.Pop();
//            var b = mystack.Peek();
//            mystack.Clear();
//            bool has2 = mystack.Contains(2);
//            bool hasz = mystack.Contains("z");
//            Console.WriteLine("size of stack" + mystack.Count);

//            //my stack

//            Queue myqueue01 = new Queue();
//            myqueue01.Enqueue(1);
//            myqueue01.Enqueue(2);
//            myqueue01.Enqueue(3);
//            myqueue01.Enqueue(4);
//            myqueue01.Enqueue(5);
//            myqueue01.Enqueue(5);
//            myqueue01.Enqueue(5);
//            myqueue01.Enqueue("Bob");
//            myqueue01.Enqueue("Tom");
//            myqueue01.Enqueue("Jerry");
//            var item01 = myqueue01.Dequeue();
//            Console.WriteLine("Coutain 5 in  Queue" + myqueue01.Contains(5));
//            Console.WriteLine("Coutain 10 in  Queue" + myqueue01.Contains(10));
//            Console.WriteLine("size of Queue" + myqueue01.Count);
//            myqueue01.Clear();
//            Console.WriteLine("size of Queue" + myqueue01.Count);



//            Console.ReadLine();
//        }
//    }
//}




























//ArrayList list01 = new ArrayList();
//list01.Add(1);
//list01.Add(2);
//list01.Add(3);
//list01.Add(4);
//list01.Add(5);
//for (int i = 0; i < list01.Count; i++)
//{
//    Console.WriteLine($"Item {i}: {list01[i]}");
//}
//list01.RemoveAt(3);
//list01.Insert(4, 10);
//Console.ReadLine();
//Hashtable ht01 = new Hashtable();
//ht01.Add("a", 1);
//ht01.Add("b", 1);
//ht01.Add("c", 1);
//ht01.Add("d", 1);
//ht01.Add("e", 1);
//ht01.Add(1, "c");
//ht01.Remove(1);
//if (ht01.ContainsKey("c"))
//    ht01.Remove("c");
//if (ht01.ContainsKey("f"))
//    ht01.Remove("f");
//bool hasValue = ht01.ContainsValue(3);
//hasValue = ht01.ContainsValue(6);

//foreach (DictionaryEntry item in ht01)
//{
//    Console.WriteLine(item.Key + ": " + item.Value);
//    Console.WriteLine();
//};
//Console.WriteLine("==============VALUES==================");
//{
//    foreach (var key in ht01.Keys)
//    {
//        Console.WriteLine(key);
//    }
//Console.WriteLine("=============VALUES=============");
//    {
//    foreach (var key in ht01.Values)
//        {
//            Console.WriteLine(value);
//        };
//        hashtable 
//    }
//}





//for (int i = 0; i < list01.Count; i++)
//{
//    Console.WriteLine($"Item {i}: {list01[i]}");
//}
//list01.RemoveAt(3);
//list01.Insert(4,10);
//Console.WriteLine($"List01 Count: {list01.Count}");
//ArrayList list02 = new ArrayList();
//list02.Add("A1");
//list02.Add("B1");
//list02.Add("C1");
//list02.Add("D1");
//list02[2] = "C2";
//list02.Add(100);
//list02.Add(3.14f);
//list01.InsertRange(4, list02);
//list02.Remove("C1");
//list02.Remove("C2");
//list02.Clear();
//list01.RemoveRange(6, 2);
//Console.WriteLine($"List01 Count: {list01.Count}");
//Console.ReadLine();


//    }

//    }
//}
