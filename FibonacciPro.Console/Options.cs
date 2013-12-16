using CommandLine;
using CommandLine.Text;
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
        [Option('n', "interactive", HelpText = "Enables interactive mode where the user will be prompted for input values.")]
        protected bool InteractiveMode
        {
            get;
            set;
        }

        /// <summary>
        /// Handles special exceptions to override Interactive mode argument.
        /// </summary>
        /// <returns></returns>
        public bool UseInteractiveMode()
        {
            if (InputNumber > 0)
                //Direct input value was provided in the command line
                return false;

            if (InteractiveMode && !string.IsNullOrWhiteSpace(InputFile))
                //Interactive mode was indicated, but an input file was passed
                return false;
            if (!InteractiveMode && string.IsNullOrWhiteSpace(InputFile))
                //InteractiveMode was not indicated, but no input file was passed
                return true;

            return InteractiveMode;
        }

        [Option('i',"in", HelpText="File path to input file. XML or plain text accepted.")]
        public string InputFile { get; set; }

        public enum FileType { Undefined, PlainText, Xml }

        [Option('o',"out",HelpText="File path to output file. Files ending in .xml will be an XML format.")]
        public string OutputFile { get; set; }

        public FileType OutputFileType
        {
            get { return GetFileTypeFromPath(OutputFile); }
        }

        public FileType InputFileType
        {
            get { return GetFileTypeFromPath(InputFile); }
        }

        private FileType GetFileTypeFromPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !path.Contains('.'))
                return FileType.Undefined;

            var extension = path.Substring(path.LastIndexOf('.'));

            switch (extension)
            {
                case ".txt":
                    return FileType.PlainText;
                case ".xml":
                    return FileType.Xml;
            }

            return FileType.Undefined;
        }

        [ValueOption(0)]
        public int InputNumber { get; set; }

        [HelpOption]
        public string GetUsage() {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
