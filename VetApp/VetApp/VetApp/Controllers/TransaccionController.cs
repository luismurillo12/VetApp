using Microsoft.AspNetCore.Mvc;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class TransaccionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult CierreCaja()
        {
            return View();
        }

        public IActionResult Cobro()
        {
            return View();
        }
    }
}
