using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Calculate.Api.ErrorHandling
{
    public class ApiException : Exception
    {
		public ErrorContainer ApiError { get; set; }

		protected ApiException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			ApiError = new ErrorContainer();
			info.AddValue("ApiError", ApiError, typeof(ErrorContainer));
		}

		public ApiException(string message, Exception innerException)
			: base(message, innerException)
		{
			ApiError = new ErrorContainer
			{
				ErrorDetail = new List<string> { message }
			};
		}

		public ApiException(string message, Exception innerException, UserErrorType error)
			: this(message, innerException, (short)error, EnumExtentions.DescriptionAttr<UserErrorType>(error))
		{
		}

		public ApiException(string message, UserErrorType error)
			: this(message, null, error)
		{
		}

		public ApiException(string message, short error)
			: this(message, null, error)
		{
		}

		public ApiException(string message, Exception innerException, short error)
			: this(message, innerException, error, "")
		{
		}

		public ApiException(string message, Exception innerException, short error, string errorDescr)
			: base(message, innerException)
		{
			ApiError = new ErrorContainer(message, error, errorDescr);
		}

		public ApiException(ErrorContainer error)
			: this((error.ErrorDetail.Count() > 0) ? error.ErrorDetail[0] : "", null, error.ErrorCode)
		{
			ApiError = error;
		}
	}
}
