using MyList;

namespace MyList
{
    public class Program
    {

        static void Main(string[] args)
        {
            //List<string> list = new List<string>();
            //list.Add("meet");
            //list.Add("harsh");
            //list.Add("khushal");

            //foreach (string name in list)
            //{
            //    Console.WriteLine(name);    
            //}

            //list.Remove("harsh");

            //foreach (string name in list)
            //{
            //    Console.WriteLine(name);
            //}

            MyList<string> myList = new MyList<string>();
            myList.Add("12");
            myList.Add("13");
            myList.Add("14"); 
            myList.Add("15");

            //int[] data = (int[]);
            foreach (string i in myList.GetAll())
            {
                Console.WriteLine(i);
            }

            myList.Remove("13");

            foreach (string i in myList.GetAll())
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();

        }
    }
}