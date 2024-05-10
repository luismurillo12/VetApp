using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using VetApp.Entities;
using VetApp.Models;
using VetApp.Services;

namespace VetApp.Controllers
{

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;
        private readonly AuthModel _authModel; 

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _authModel = new AuthModel(configuration);
        }

        [HttpGet]
        public IActionResult Index() //mi login
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserObj userObj) 
        {
            try
            {
                var result = _authModel.Login(userObj);
                if (result != null)
                {
					HttpContext.Session.SetString("UserNickName", result.UserNickName);
					HttpContext.Session.SetString("RolName", result.RolName);
					HttpContext.Session.SetString("UserPicture", result.UserPicture);
					HttpContext.Session.SetInt32("UserIdRol", result.IdRol);

                    if(result.IdRol == 2){
                        return RedirectToAction("Supplier", "Supplier");
                    }

					return RedirectToAction("Forms", "Forms");
                }
                else
                {
                    ViewBag.MsjError = "La información indicada es incorrecta.";
                    return View("Index");
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

		[HttpGet]
		[FilterSecurity]
		public IActionResult CloseSession()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RequestNewPasswordEmailSend()
        {
            return View();
        }

		[HttpPost]
		public JsonResult RequestNewPasswordEmailSend(UserObj userObj)
		{
            var sendEmail = _authModel.RequestNewPasswordEmailSend(userObj);
			return Json(sendEmail);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}