using System;
using System.Collections;

namespace Collection
{

    class ListDemo
    {
        int id;
        string name;
    }
    class demo
    {
        public static void Main(string[] args)
        {
            /*  Array  */



            int[] arrayvalue = { 32, 65, 87, 54, 76 };

            foreach (int i in arrayvalue)
            {
                Console.WriteLine(i);
            }


            /*  ArrayList  */


            ArrayList arraylist = new ArrayList();
            arraylist.Add(9);
            arraylist.Add(8);
            arraylist.Add(7);

            foreach(int i in arraylist)
            {
                Console.WriteLine(i);
            }

            arraylist.Insert(2, 89);

            foreach (int i in arraylist)
            {
                Console.WriteLine(i);
            }


            /* List  */

            var a=new List<string>();
            a.Add("nike");
            a.Add("fila");
            a.Add("puma");

            foreach(string printa in a)
            {
                Console.WriteLine(printa);
            }

            var b=new List<int>() { 1, 2, 3, 4, 5 };

            b.Remove(3);
            foreach(int printb in b)
            {
                Console.WriteLine(printb);
            }


            /*  LinkedList  */


            var c = new LinkedList<int>();
            c.AddLast(31);
            c.AddLast(21);
            c.AddLast(22);
            c.AddFirst(54);

            LinkedListNode<int> d = c.Find(22);
            c.AddAfter(d, 76);
            c.AddBefore(d, 56);

            foreach(var view in c)
            {
                Console.WriteLine(view);
            }


            /*  Stack  */

            Stack<string> stack = new Stack<string>();
            stack.Push("sg");
            stack.Push("reebok");
            stack.Push("ton");

            foreach (var view in stack)
            {
                Console.WriteLine(view);
            }

            stack.Pop();

            foreach (var view in stack)
            {
                Console.WriteLine(view);
            }

            Console.WriteLine("======"+stack.Peek());


            /*  Queue  */


            Queue<string> queue = new Queue<string>();
            queue.Enqueue("cricket");
            queue.Enqueue("volleyball");
            queue.Enqueue("kabaddi");
            queue.Enqueue("khokho");

            foreach (var viewqueue in queue)
            {
                Console.WriteLine(viewqueue);
            }

            queue.Dequeue();

            foreach (var viewqueue in queue)
            {
                Console.WriteLine(viewqueue);
            }

            Console.WriteLine("====="+queue.Peek());


            /* HashSet */

            var hs=new HashSet<int>(){ 12, 432, 54, 66 };

            foreach(var viewhashset in hs)
            {
                Console.WriteLine(viewhashset);
            }



            /* Dictionary */


            Dictionary<int,string> dc = new Dictionary<int,string>();
            dc.Add(1, "chess");
            dc.Add(2, "TT");
            dc.Add(3, "longjump");
            dc.Add(4, "highjump");

            foreach(var viewdictionary in dc)
            {
                Console.WriteLine(viewdictionary);
            }

        }
    }
}