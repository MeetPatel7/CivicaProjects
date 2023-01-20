using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesssModifiers2;

namespace AccessModifiers
{
    public  class DemoAccessModifier:Class1
    {
        public int id;
        private string name;
        protected string city;
        internal string state;
        protected internal int pincode;

        protected internal void forprotectedinternal()
        {
            Console.WriteLine("pin code = " + pincode);
        }
        internal void demointernal()
        {
            Console.WriteLine("Address:"+state);
        }

        public void SetId(int id)
        { 
            this.id = id; 
        }
        public int GetId()
        { 
            return this.id; 
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }

        public void accessmodofiersprotected(string e)
        {
            this.email = e;
            Console.WriteLine("hello!-------------"+email);
        }
 
    }

    public class DemoProtected:DemoAccessModifier
    {
        public void methodprotected(string c)
        {
            this.city=c;
            
            Console.WriteLine("for protected"+city);
            accessmodofiersprotected(email); 
        }
    }
}
