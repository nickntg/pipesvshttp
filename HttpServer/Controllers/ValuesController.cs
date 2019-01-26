using Microsoft.AspNetCore.Mvc;

namespace HttpServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		[HttpPost]
		public void Post([FromBody] O value)
		{
		}
	}

	public class O
	{
		public string Value { get; set; }
	}
}