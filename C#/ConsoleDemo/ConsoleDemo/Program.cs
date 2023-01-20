using System;
using System.Text;
//using System;

namespace ConsoleDemo
{
    class Demo
    {
        static void Main(string[] args)
        {
            try
            {
                int a, b, c;
                Console.Write("enter value 1:");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("enter value 2:");
                b = Convert.ToInt32(Console.ReadLine());
                c = a + b;
                Console.Write(c);

                Console.Write("enter value 3:");
                a = Int32.Parse(Console.ReadLine());
                Console.Write("enter value 4:");
                b = Convert.ToInt32(null);
                c = a + b;
                Console.WriteLine("a=" + a.ToString() + " b=" + b.ToString());
                Console.Write(c);

            }
            catch(DivideByZeroException ex)
            {
                Console.Write(ex.Message);
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}