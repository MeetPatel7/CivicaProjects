using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    class GenericClassDemo<T, U>
    {
        T a;
        U b;

        public GenericClassDemo(T x, U y)
        {
            this.a = x;
            this.b = y;
        }
        public void data()
        {
            Console.WriteLine(a + " " + b);
        }

    }

    class GenericMethodDemo
    {
        public void methoddemo<T, U>(T a, U b)
        {
            Console.WriteLine(a + " " + b);
        }
    }
    class GenericMain
    {
        static void Main(string[] args)
        {
            GenericClassDemo<int, string> gcd = new GenericClassDemo<int, string>(2, "nitya");
            gcd.data();
            GenericClassDemo<int, int> gcd2 = new GenericClassDemo<int, int>(1, 20000);
            gcd2.data();

            GenericMethodDemo gmd = new GenericMethodDemo();
            gmd.methoddemo(1, 2);
            gmd.methoddemo(1, "hii");
            gmd.methoddemo("hii", "hello");
        }
    }
}