using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FibonacciPro.ConsoleApplication.IO
{
    public class XmlIOHandler : IInputHandler, IOutputHandler
    {
        private string _path;
        private int _number;

        public XmlIOHandler(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("path must not be an empty string", "path");

            _path = path;
        }
    
        public int GetNumber()
        {
            try
            {
                var doc = XDocument.Load(_path);
                var result = Convert.ToInt32(doc.Element("fibinput").Value);
                return result;
            }
            catch (XmlException ex)
            {
                throw new ApplicationException("There was a problem loading the input XML document. Check the format and validity of the XML.");
            }
        }

        public void Write(double[] results)
        {
 	        throw new NotImplementedException();
        }
    }
}
