using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace FibonacciPro.ConsoleApplication.IO
{
    public class ConsoleIOHandler : TextStreamIOHandler
    {
        public ConsoleIOHandler() : base(Console.In, Console.Out) { }
    }
}
