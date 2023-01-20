using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Exception
{
    //[Serializable]
    public class EnrollmentLimitReachedException : IOException
    {
        public EnrollmentLimitReachedException():base("can not be enrol for more than 3 course.") 
        {}
    
    }
}
