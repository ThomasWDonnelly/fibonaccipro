using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Fibonacci.Web.Models;

namespace Fibonacci.Web.Controllers
{
    public class HomeController : Controller
    {
        //POST: "/"
        [HttpPost]
        public ActionResult Index(IndexViewModel viewModel)
        {
            //redirect if not logged in yet
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account", new { returnUrl = "/" + viewModel.InputValue });

            return View(viewModel);
        }

        //GET: /n (optional n)
        [HttpGet]
        public ActionResult Index(string n = "") //using "n" since it is appropriate in a mathematical sense..  should I use a more descriptive name?
        {
            //redirect if not logged in yet
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account", new { returnUrl = "/" + n });

            //path: "/" (no parameter)
            if (n == "")
            {
                Debug.WriteLine("n was null");
            }
            else
            {
                Debug.WriteLine("n was NOT null");
            }

            return View(new IndexViewModel
            {
                InputValue = n
                //Results = new results
            });
        }


        public ActionResult TestServerError()
        {
            throw new Exception("Testing 500 error");
        }
    }
}