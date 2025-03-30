using System;
using System.Collections.Generic;
using System.Text;

namespace Jenina.Static.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception? InnerException(this Exception exception)
        {
            if (exception != null && exception.InnerException != null)
            {
                return InnerException(exception.InnerException);
            }

            return exception;
        }
    }
}
