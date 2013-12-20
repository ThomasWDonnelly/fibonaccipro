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
        public ActionResult Index(IndexViewModel inputViewModel)
        {
            //redirect if not logged in yet
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account", new { returnUrl = "/" + inputViewModel.InputValue });

            //prep return view model with results
            var viewModel = new IndexViewModel { InputValue = inputViewModel.InputValue };

            //only get results if input more than 0
            if (inputViewModel.InputValue > 0) viewModel.Results = FibonacciCalculator.Calculate(inputViewModel.InputValue);

            //return results via viewModel
            return View(viewModel);
        }

        //GET: /n (optional n)
        [HttpGet]
        public ActionResult Index(int n = 0) //using "n" since it is appropriate in a mathematical sense..  should I use a more descriptive name?
        {
            //redirect if not logged in yet
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account", new { returnUrl = "/" + n });

            //prep return view model with results
            var viewModel = new IndexViewModel {InputValue = n};

            //only get results if input more than 0
            if (n > 0) viewModel.Results = FibonacciCalculator.Calculate(n);
            
            //return results via viewModel
            return View(viewModel);
        }

        public ActionResult TestServerError()
        {
            throw new Exception("Testing 500 error");
        }
    }
}