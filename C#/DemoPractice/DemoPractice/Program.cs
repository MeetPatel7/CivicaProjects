using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DemoSingleton ds = DemoSingleton.Instance;
            ds.name = "meet";
            ds.demomessage();

            Mobile m=new Mobile();
            m.camara(48);
            m.buttons(3);
            m.screen(16);
            m.storage(128);
            m.ram(8);
            Console.WriteLine();

            Tournament t=new Tournament();
            t.Games();
            Console.WriteLine();
            t.pname();
            Console.WriteLine();

            DerivedClass dc = new DerivedClass(100,200);
            dc.swap();
           

            Console.ReadLine();
        }
    }

    //------------------------ Singleton Class -----------------------------------

    public sealed class DemoSingleton
    {
        private DemoSingleton()
        { }

        private static DemoSingleton instance=null;
        public string name="harsh";
        public static DemoSingleton Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new DemoSingleton();
                }
                return instance; 
            }
        }

        public void demomessage()
        {
            Console.WriteLine($"welcome {name}");
        }
    }

    //------------------------ Multiple Inheritance ------------------------------

    interface IMobileBody
    { 
        void camara(int c);

        void buttons(int b);

        void screen(int s);
    }

    interface IMobileMemory
    {
        void storage(int st);

        void ram(int r);

    }

    public class Mobile:IMobileBody, IMobileMemory
    {
        public void camara(int x)
        {
            Console.WriteLine($"camara {x} pixel");
        }

        public void buttons(int y)
        {
            Console.WriteLine($"number of buttons {y} ");
        }

        public void screen(int z)
        {
            Console.WriteLine($"screen size {z} inch");
        }

        public void storage(int u)
        {
            Console.WriteLine($"storage {u} GB");
        }

        public void ram(int v)
        {
            Console.WriteLine($"ram {v} GB");
        }
    }

    //-----------------------------------------------------------------------------------
    interface ISports
    {
        void Games();
    }

    interface IPlayers
    {
        void pname();
    }

    public class Sports:ISports
    {
        public void Games()
        {
            ArrayList al = new ArrayList();

            al.Add("Volleyball");
            al.Add("Kabaddi");
            al.Add("Kho-Kho");
            al.Add("Cricket");

            Console.WriteLine("Name of Sports");

            foreach(string m in al)
            {
                Console.WriteLine(m);
            }
        }
    }

    public class Player:IPlayers
    {
        public void pname()
        {
            ArrayList al = new ArrayList();

            al.Add("Meet");
            al.Add("Dhyey");
            al.Add("Raj");
            al.Add("Mihir");
            al.Add("harshil");
            al.Add("darshan");

            Console.WriteLine("Name of Players");

            foreach(string n in al)
            {
                Console.WriteLine(n);
            }
        }
    }

    public class Tournament
    {
        Sports sports = new Sports();
        Player player = new Player();

        public void Games()
        {
            sports.Games();
        }

        public void pname()
        {
            player.pname();
        }
    }


    //------------------------- method overriding -------------------------------------


    public class BaseClass
    {
        public int a,b;
        public BaseClass(int a,int b)
        {
            this.a = a;
            this.b = b;
        }
        public virtual void swap()
        {
            Console.WriteLine($"base class passed values {a}, {b}");

            int c = a;
            a= b;
            b= c;

            Console.WriteLine($"base class swaped values {a}, {b}");
        }
    }

    public class DerivedClass:BaseClass
    {
        public DerivedClass(int a, int b) : base(a, b) { }
    
        
        public override void swap()
        {
            base.swap();

            Console.WriteLine($"child class passed values {a}, {b}");

            int c = a;
            a = b;
            b = c;

            Console.WriteLine($"child class swaped values {a}, {b}");
        }
    }

}
