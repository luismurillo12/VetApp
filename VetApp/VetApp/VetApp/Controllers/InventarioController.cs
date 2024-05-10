using Microsoft.AspNetCore.Mvc;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class InventarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Inventario()
        {
            return View();
        }
        
        public IActionResult AgregarInventario()
        {
            return View();
        }
    }
}
