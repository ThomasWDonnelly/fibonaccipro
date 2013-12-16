﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication.IO
{
    public class GenericIOHandler : IInputHandler, IOutputHandler {
    
        public Action<BigInteger[]> OutputHandler { get; set; }

        public Func<int> InputHandler { get; set; } 

        public void Write(BigInteger[] results)
        {
            OutputHandler(results);
        }

        public int GetNumber()
        {
            return InputHandler();
        }
    }
}
