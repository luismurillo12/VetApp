using Microsoft.AspNetCore.Mvc;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class ProveedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Proveedores()
        {
            return View();
        }

        public IActionResult AgregarProveedores()
        {
            return View();
        }
    }
}
