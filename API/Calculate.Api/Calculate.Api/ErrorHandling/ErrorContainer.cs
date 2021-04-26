
using System.Collections.Generic;

namespace Calculate.Api.ErrorHandling
{
    public class ErrorContainer
    {
		public short ErrorCode { get; set; }

		public string ErrorType { get; set; }

		public List<string> ErrorDetail { get; set; }

		public ErrorContainer()
		{
			ErrorCode = 0;
			ErrorDetail = new List<string>();
		}

		public ErrorContainer(string message, short error, string errorType)
		{
			ErrorCode = error;
			ErrorType = errorType;
			ErrorDetail = new List<string> { message };
		}
	}
}
