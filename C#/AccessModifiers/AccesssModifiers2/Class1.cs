using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesssModifiers2
{
    public class Class1
    {
        internal string country;
        protected string email;
        protected internal int mobileno;

        protected internal void demoprotectedinternal()
        {
            Console.WriteLine("mobile no.=" + mobileno);
        }
    }
}
