using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Exception
{
    public class AlreadyEnrollException:IOException
    {
        //public AlreadyEnrollException() {}
        public AlreadyEnrollException(String courseName)
            :base(String.Format("already enrol for the course {0}",courseName)) 
        {}
    }
}
