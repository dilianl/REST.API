
using System.ComponentModel;
using System.Xml.Serialization;

namespace Calculate.Api.ErrorHandling
{
    public enum UserErrorType
    {
		[XmlEnum("400")]
		[Description("Bad request")]
		BadRequest = 400,
		[XmlEnum("401")]
		[Description("Unauthorized")]
		Unauthorized = 401,
		[XmlEnum("403")]
		[Description("Forbidden")]
		Forbidden = 403,
		[XmlEnum("404")]
		[Description("Resource not found")]
		NotFound = 404,
		[XmlEnum("422")]
		[Description("Unprocessable Entity")]
		UnprocessableEntity = 422,
		[XmlEnum("500")]
		[Description("The server encountered an error and could not complete your request")]
		InternalServerError = 500,
		[XmlEnum("501")]
		[Description("The requested functionality is not implemented")]
		NotImplemented = 501,
		[XmlEnum("204")]
		[Description("No Content")]
		NoContent = 204
	}
}
