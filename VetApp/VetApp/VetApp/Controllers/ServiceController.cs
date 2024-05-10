using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Drawing;
using System.Text;
using System.IO;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class ServiceController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly ServiceModel _service;
        public List<ServiceObj> _servicesObject;
        public ServiceController(IConfiguration configuration)
        {
            _configuration = configuration;
            _service = new ServiceModel(configuration);
            _servicesObject = _service.GetServices();

        }


        public IActionResult Service()
        {
            ViewBag.Services = _servicesObject;
            return View();
        }


        [HttpPost]
        public JsonResult CreateService(ServiceObj serviceObj)
        {

            var createService = _service.CreateService(serviceObj);
            return Json(createService);
        }

        [HttpGet]
        public JsonResult GetService(int idService)
        {
            var user = _servicesObject.Where(data => data.idService == idService).FirstOrDefault();
            return Json(user);
        }

        [HttpPut]
        public JsonResult UpdateService(ServiceObj serviceObj)
        {
            var createService = _service.UpdateService(serviceObj);
            return Json(createService);
        }

        [HttpDelete]
        public JsonResult DeleteService(int idService)
        {
            var service = _service.DeleteService(idService);
            return Json(service);
        }

    }
}