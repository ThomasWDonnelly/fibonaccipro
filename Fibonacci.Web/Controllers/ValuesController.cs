using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fibonacci.Web.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/5/<format>
        public string Get(int urlInputValue, string format)
        {
            
            //User.Identity.IsAuthenticated
                
            return string.Format("Input Value: {0} - Format: {1}", urlInputValue, format);
        }

    }
}