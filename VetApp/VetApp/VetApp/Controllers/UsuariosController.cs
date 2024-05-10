using Microsoft.AspNetCore.Mvc;
using VetApp.Services;

namespace VetApp.Controllers
{
	//[FilterSecurity]
	//[ResponseCache(NoStore = true, Duration = 0)]
	public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Cliente()
        {
            return View();
        }
        
        public IActionResult AgregarCliente()
        {
            return View();
        }
       
    }
}
