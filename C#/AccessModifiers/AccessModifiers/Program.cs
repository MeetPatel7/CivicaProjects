using System;

using AccesssModifiers2;

namespace AccessModifiers
{
    internal class Program:Class1
    {
        static void Main(string[] args)
        {
            DemoAccessModifier dam = new DemoAccessModifier();
            dam.state = "gujarat";
            dam.demointernal();
            dam.accessmodofiersprotected("meet");
            dam.mobileno
            /*dam.SetId(1);
            dam.SetName("meet");
            Console.WriteLine(dam.GetId());
            Console.WriteLine(dam.GetName());
            //Console.ReadLine();*/
            
            //dam.id=10; 
            Class1 c = new Class1();
            //c.country = "india";
            
            
          
            DemoProtected dp = new DemoProtected();
            dp.methodprotected("vadoadar");
            dp.pincode = 391110;
            dp.forprotectedinternal();
            
            Console.ReadLine();

        }
    }
}
