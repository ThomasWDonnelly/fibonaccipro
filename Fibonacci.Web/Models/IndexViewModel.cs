using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Web;

namespace Fibonacci.Web.Models
{
    public class IndexViewModel
    {
        public string InputValue { get; set; }
        public BigInteger[] Results { get; set; }
    }
}