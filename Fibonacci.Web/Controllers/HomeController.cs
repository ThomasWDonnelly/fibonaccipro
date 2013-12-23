using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Fibonacci.Web.Models;
using FibonacciPro.ConsoleApplication;

namespace Fibonacci.Web.Controllers
{
    public class HomeController : Controller
    {
        //POST: "/"
        [HttpPost]
        [Authorize]
        public ActionResult Index(IndexViewModel inputViewModel)
        {
            //prep return view model with results
            var viewModel = new IndexViewModel { InputValue = inputViewModel.InputValue };

            //only get results if input more than 0
            //if (inputViewModel.InputValue > 0) viewModel.Results = FibonacciCalculator.Calculate(inputViewModel.InputValue);

            //return results via viewModel
            return View(viewModel);
        }

        //GET: /<n> (optional n)
        [HttpGet]
        [Authorize]
        public ActionResult Get(int urlInputValue)
        {
            //prep return view model with results
            var viewModel = new IndexViewModel {InputValue = urlInputValue};

            //only get results if input more than 0
            //if (urlInputValue > 0) viewModel.Results = FibonacciCalculator.Calculate(urlInputValue);
            
            //return results via viewModel
            return View("Index", viewModel);
        }

        //GET: "/"
        [HttpGet]
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }


        public ActionResult TestServerError()
        {
            throw new Exception("Testing 500 error");
        }
    }
}