using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttributeRouting.Controller
{
    [Route("{controller}")]
    public class EmployeeController : ControllerBase
    {
        static List<string> _names = new List<string>();
        static EmployeeController()
        {
            _names.Add("mahesh");
            _names.Add("suresh");
            _names.Add("naresh");
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _names;
        }
    }
}
