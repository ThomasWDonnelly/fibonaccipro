using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication
{
    /// <summary>
    /// Options to be passed into the application from the command line
    /// </summary>
    class Options
    {
        [Option('n',"interactive", MutuallyExclusiveSet="input", HelpText="Enables interactive mode where the user will be prompted for input values.", DefaultValue=true)]
        public bool InteractiveMode { get; set; }

        [Option('i',"in", MutuallyExclusiveSet="input", HelpText="File path to input file. XML or plain text accepted.")]
        public string InputFile { get; set; }

        public enum FileType { PlainText, Xml }

        [Option('o',"out",HelpText="File path to output file. Files ending in .xml will be an XML format.")]
        public string OutputFile { get; set; }

        public FileType OutputFileType { get; set; }

        public FileType InputFileType { get; set; }

        public int InputNumber { get; set; }
    }
}
