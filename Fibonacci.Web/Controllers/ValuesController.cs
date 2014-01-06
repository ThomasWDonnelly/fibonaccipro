using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Fibonacci.Lib.Calculators;

namespace Fibonacci.Web.Controllers
{
    public class ValuesController : ApiController
    {

        private readonly IFibonacciCalculator _fibonacciCalculator;

        //constructor
        public ValuesController(IFibonacciCalculator fibonacciCalculator)
        {
            _fibonacciCalculator = fibonacciCalculator;
        }

        // GET api/5/<format>
        public HttpResponseMessage Get(int urlInputValue, string format)
        {
            //check authorization, return 401 if not
            if (!User.Identity.IsAuthenticated)
            {
                return this.Request.CreateResponse(
                    HttpStatusCode.Unauthorized,
                    new { authorized = "false", numberOfResults = 0, results = new object() });
            }

            //get results array from calculator - converted to strings to avoid JS scientific notation in view results
            var resultsArray = Array.ConvertAll(
                (BigInteger[])_fibonacciCalculator.Calculate(urlInputValue), 
                bi => bi.ToString()
                );

            //handle diff formats

            //send back
            return this.Request.CreateResponse(
                HttpStatusCode.OK,
                new { authorized = "true", numberOfResults = resultsArray.Count(), results = (object)resultsArray });

        }

    }

}