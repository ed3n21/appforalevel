using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace level.Filters.Exceptions
{
    public class NotFindDataException : ApiException
    {
        public NotFindDataException(string message) : base(message, ErrorCodes.DataNotExist) { 
        }
    }
}