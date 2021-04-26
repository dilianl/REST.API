using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Api.General
{
    public static class Utility
    {
        /// <summary>
        /// Returns the exception message including the inner exepetion messages.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExceptionMessages(Exception ex)
        {
            StringBuilder str = new StringBuilder();

            if (ex == null)
                return str.ToString();

            str.Append(ex.Message);

            Exception innerException = ex;
            while (true)
            {
                if (innerException.InnerException == null)
                    break;

                str.AppendFormat(" -> {0}", innerException.InnerException.Message);

                innerException = innerException.InnerException;
            }

            return str.ToString();
        }

    }
}
