using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Common.Exceptions
{
    public class SearchFightException : Exception
    {
        public SearchFightException(string message) : base(message) { }
        public SearchFightException(string message, Exception innerException) : base(message, innerException) { }
    }
}
