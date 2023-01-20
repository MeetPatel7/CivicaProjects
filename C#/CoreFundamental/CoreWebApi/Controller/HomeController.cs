using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controller
{
    
    
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Hello World";
        }

        public void AboutUs()
        {
            
        }
    }
}
