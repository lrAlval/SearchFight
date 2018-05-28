using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Common.Exceptions
{
    public class SearchFightHttpException : SearchFightException
    {
        public SearchFightHttpException(string message) : base(message) { }
        public SearchFightHttpException(string message, Exception innerException) : base(message, innerException) { }
    }
}
