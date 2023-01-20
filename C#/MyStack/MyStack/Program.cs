using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program<T>
{
    int length;
    T[] stack;
    int top;

    public Program(int maxdata)
    {
        length = maxdata;
        stack = new T[length + 1];
    }

    public int push(T data)
    {
        if (top == length - 1)
        {
            return -1;
        }
        else
        {
            top += 1;
            stack[top] = data;

            /*foreach (string str in stack[])
            {
                Console.WriteLine();
            }*/
        }
        return 0;
    }

    public T pop()
    {
        T popdata;
        T temp=default(T);

        if(!(top<=0))
        {
            popdata = stack[top];
            top=top-1;
            return popdata;
        }

        return temp;
    }

    public T[] GetAllStackElements()
    {
        T[] alldata = new T[top+1];
        Array.Copy(stack, 0, alldata, 0, top+1);
        return alldata;
    }
}
namespace MyStack
{
    public class Program
    {
            static void Main(string[] args)
            {
                int capacity;
                Console.WriteLine("Enter Capacity of Stack :");
                capacity = int.Parse(Console.ReadLine());

                Program<string> mystack = new Program<string>(capacity);

                do
                {
                    Console.WriteLine("Press 1 for push");
                    Console.WriteLine("Press 2 for pop");
                    Console.WriteLine("Press 3 for view stack");

                    Console.WriteLine("Enter your option");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter your data");
                                string d = Console.ReadLine();
                                int result = mystack.push(d);

                                if (result != -1)
                                {
                                    Console.WriteLine("data pushed");
                                }
                                else
                                {
                                    Console.WriteLine("stack overflow");
                                }
                                break;
                            }
                        case 2:
                            {   
                                string result = mystack.pop();

                                if(result != null)
                                {
                                    Console.WriteLine(result +"  removed");
                                }
                                else
                                {
                                    Console.WriteLine("stack overflow");
                                }
                                break;
                            }
                        case 3:
                            {
                                string[] alldata = mystack.GetAllStackElements();

                                foreach (string data in alldata)
                                {
                                    Console.WriteLine(data);
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("please choose a vaild option");
                                break;
                            }
                    }
                }
                while (true);
            }
    }
}

