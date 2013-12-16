using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication.IO
{
    public class GenericIOHandler : IInputHandler, IOutputHandler {
    
        public Action<double[]> OutputHandler { get; set; }

        public Func<int> InputHandler { get; set; } 

        public void Write(double[] results)
        {
            OutputHandler(results);
        }

        public int GetNumber()
        {
            return InputHandler();
        }
    }
}
