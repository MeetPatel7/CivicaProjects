using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    public class MyList<T> where T:class
    {
        List<T> list = new List<T>();
        public void Add(T a)
        {
            list.Add(a);
        }

        public void Remove(T a)
        {
            list.Remove(a);
        }

        public IEnumerable<T> GetAll()
        {
            return list;
        }
    }
}
