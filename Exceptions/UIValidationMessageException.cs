using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.Exceptions
{
    public class UIValidationMessageException : Exception
    {
        public UIValidationMessageException(string message) : base(message)
        {
        }
    }
}
