using HexagonalArchitecture.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
	public IActionResult Content(object obj)
	{
		return Content(obj.ToJson(), "application/json");
	}
}
