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
	public class ClientController : Controller
    {
        private readonly ClientModel _client;
        public List<ClientObj> _clientsObject;
		private readonly IConfiguration _configuration;
		public ClientController(IConfiguration configuration)
        {
			_configuration = configuration;
			_client = new ClientModel(configuration);
            _clientsObject = _client.GetClients();

        }


        public IActionResult Client()
        {
            ViewBag.Clients = _clientsObject;
            return View();
        }

        public IActionResult AgregarEmpleado()
        {
            return View();
        }

        public IActionResult Employee()
        {

            return View();
        }

        public IActionResult EditarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateClient(ClientObj clientObj)
        {

            var createClient = _client.CreateClient(clientObj);
            return Json(createClient);
        }

        [HttpGet]
        public JsonResult GetClient(int idClient)
        {
            var user = _clientsObject.Where(data => data.idClient == idClient).FirstOrDefault();
            return Json(user);
        }

        [HttpPut]
        public JsonResult UpdateClient(ClientObj clientObj)
        {
            var createClient = _client.UpdateClient(clientObj);
            return Json(createClient);
        }

        [HttpDelete]
        public JsonResult DeleteClient(int idClient)
        {
            var client = _client.DeleteClient(idClient);
            return Json(client);
        }

    }
}