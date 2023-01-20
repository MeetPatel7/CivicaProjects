using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStackDemo
{
    internal class MyStack<T>
    {

        public static void Main(string[] args)
        {

            do
            {
                Console.WriteLine("Press 1 for push");
                Console.WriteLine("Press 2 for pop");
                Console.WriteLine("Press 3 for exit");

                Console.WriteLine("Enter your option");
                int option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                    {
                            Console.WriteLine("");
                    }
                }

            }
            while (true);
        }
    }
}
