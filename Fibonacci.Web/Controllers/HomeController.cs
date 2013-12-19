using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fibonacci.Web.Models;

namespace Fibonacci.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(IndexViewModel viewModel)
        {
            //path: "/" (no parameter)
            if (viewModel.InputValue == null)
            {
                Debug.WriteLine("n was null");
            }
            else
            {
                Debug.WriteLine("n was NOT null");
                }
            return View();
        }
    }
}