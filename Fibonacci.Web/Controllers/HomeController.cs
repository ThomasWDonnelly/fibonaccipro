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
        public ActionResult Index(IndexViewModel viewModel)
        {
            //redirect if not logged in yet
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account", new {returnUrl = "/" + viewModel.InputValue});
       
            //path: "/" (no parameter)
            if (viewModel.InputValue == null)
            {
                Debug.WriteLine("n was null");
            }
            else
            {
                Debug.WriteLine("n was NOT null");
            }
            return View(viewModel);
        }
    }
}