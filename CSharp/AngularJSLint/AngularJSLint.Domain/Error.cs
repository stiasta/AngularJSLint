using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSLint.Domain
{
    public class Error
    {
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string Message { get; set; }

        public Error(int linenumber, int columnnumber, string message)
        {
            LineNumber = linenumber;
            ColumnNumber = columnnumber;
            Message = message;
        }
    }
}
