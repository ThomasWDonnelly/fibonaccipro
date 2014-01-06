﻿using System;
using System.Web.Mvc;
using Fibonacci.Lib.Calculators;
using Fibonacci.Web.Models;

namespace Fibonacci.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IFibonacciCalculator _fibonacciCalculator;

        //constructor
        public HomeController(IFibonacciCalculator fibonacciCalculator)
        {
            _fibonacciCalculator = fibonacciCalculator;
        }

        //GET: "/"
        [HttpGet]
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }

        //POST: "/"
        //this logic will almost always go through JS now, but we'll just keep this here for no-JS IE6 compatibility ;)
        [HttpPost]
        [Authorize]
        public ActionResult Index(IndexViewModel inputViewModel)
        {
            //prep return view model with results
            var viewModel = new IndexViewModel { InputValue = inputViewModel.InputValue };

            //only get results if input more than 0
            if (inputViewModel.InputValue > 0) viewModel.Results = _fibonacciCalculator.Calculate(inputViewModel.InputValue);

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
            if (urlInputValue > 0) viewModel.Results = _fibonacciCalculator.Calculate(urlInputValue);
            
            //return results via viewModel
            return View("Index", viewModel);
        }
    }
}