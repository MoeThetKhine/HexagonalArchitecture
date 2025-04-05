﻿namespace HexagonalArchitecture.Utils;

public class Result<T>
{
	public T Data { get; set; }
	public string Message { get; set; }
	public bool IsSuccess { get; set; }
	public EnumStatusCode StatusCode { get; set; }

	public static Result<T> Success(string message = "Success", EnumStatusCode statusCode = EnumStatusCode.Success)
	{
		return new Result<T>
		{
			IsSuccess = true,
			Message = message,
			StatusCode = statusCode
		};
	}
}
