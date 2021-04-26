using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Calculate.Api.ErrorHandling
{
	public class ErrorController : Controller
	{
		public IActionResult Error500()
		{
			return StatusCode(500, new ErrorContainer
			{
				ErrorCode = 500,
				ErrorType = EnumExtentions.DescriptionAttr<UserErrorType>(UserErrorType.InternalServerError),
				ErrorDetail = new List<string> { "" }
			});
		}

		public IActionResult Error(string id)
		{
			return id switch
			{
				"401" => StatusCode(401, new ErrorContainer
				{
					ErrorCode = 401,
					ErrorType = EnumExtentions.DescriptionAttr<UserErrorType>(UserErrorType.Unauthorized),
					ErrorDetail = new List<string> { "" }
				}),
				"403" => StatusCode(403, new ErrorContainer
				{
					ErrorCode = 403,
					ErrorType = EnumExtentions.DescriptionAttr<UserErrorType>(UserErrorType.Forbidden),
					ErrorDetail = new List<string> { "" }
				}),
				"404" => StatusCode(404, new ErrorContainer
				{
					ErrorCode = 404,
					ErrorType = EnumExtentions.DescriptionAttr<UserErrorType>(UserErrorType.NotFound),
					ErrorDetail = new List<string> { "" }
				}),
				"422" => StatusCode(422, new ErrorContainer
				{
					ErrorCode = 422,
					ErrorType = EnumExtentions.DescriptionAttr<UserErrorType>(UserErrorType.UnprocessableEntity),
					ErrorDetail = new List<string> { "" }
				}),
				"500" => StatusCode(500, new ErrorContainer
				{
					ErrorCode = 500,
					ErrorType = EnumExtentions.DescriptionAttr<UserErrorType>(UserErrorType.InternalServerError),
					ErrorDetail = new List<string> { "" }
				}),
				"204" => StatusCode(204, new ErrorContainer
				{
					ErrorCode = 204,
					ErrorType = EnumExtentions.DescriptionAttr<UserErrorType>(UserErrorType.NoContent),
					ErrorDetail = new List<string> { "" }
				}),
				_ => StatusCode(500, new ErrorContainer
				{
					ErrorCode = Convert.ToInt16(id),
					ErrorType = EnumExtentions.DescriptionAttr<UserErrorType>(UserErrorType.InternalServerError),
					ErrorDetail = new List<string> { "Error id: " + id }
				}),
			};
		}
	}
}
