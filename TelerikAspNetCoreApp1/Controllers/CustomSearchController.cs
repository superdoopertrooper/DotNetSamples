using Microsoft.AspNetCore.Mvc;

namespace TelerikAspNetCoreApp1.Controllers
{
	public class CustomSearchController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
