using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
       
        [HttpGet]
        public  string greeting(string str)
        {   if(str=="hello")
             return "hi";
            else
            {
                return "invalid";
            }
        }
    }
}