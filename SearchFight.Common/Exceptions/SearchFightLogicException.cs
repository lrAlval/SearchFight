using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Common.Exceptions
{
    public class SearchFightLogicException : SearchFightException
    {
        public SearchFightLogicException(string message) : base(message) { }
        public SearchFightLogicException(string message, Exception innerException) : base(message, innerException) { }
    }
}
