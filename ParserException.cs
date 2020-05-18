using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectScanner
{
    class ParserException: ApplicationException
    {
        public ParserException(String message) : base(message) { } // or predefined msg?
    }
}
