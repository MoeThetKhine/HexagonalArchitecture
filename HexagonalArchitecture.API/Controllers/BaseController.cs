namespace HexagonalArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{

	#region Content

	public IActionResult Content(object obj)
	{
		return Content(obj.ToJson(), "application/json");
	}

	#endregion
}
