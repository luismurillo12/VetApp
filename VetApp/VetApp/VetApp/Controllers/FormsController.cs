using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class FormsController : Controller
	{
		private readonly FormsModel _forms;
		private readonly EmployeeModel _user;
		private readonly ProductModel _product;
		private readonly ServiceModel _service;
		private readonly PetModel _pet;
		private readonly ClientModel _client;
		private readonly CurrentDateTimeZoneInfo _currentDateTimeZoneInfo;
		public List<FormsListObj>? _formsObject;

		private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        public FormsController(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
			_currentDateTimeZoneInfo = new CurrentDateTimeZoneInfo();
            _forms = new FormsModel(configuration);
            _user = new EmployeeModel(configuration);
            _product = new ProductModel(configuration);
            _service = new ServiceModel(configuration);
            _pet = new PetModel(configuration);
            _client = new ClientModel(configuration);
            _contextAccessor = contextAccessor;

            var roleId = contextAccessor.HttpContext?.Session.GetInt32("UserIdRol");

            if (roleId != null)
            {

                if (roleId == 1)
                {
                    
                    _formsObject = _forms.GetForms();
                    
                }
                else
                {
                   _formsObject = _forms.GetFormsForCurrentDay();
                }

            }
        }

        public IActionResult Forms()
		{

			ViewBag.Clients = _client.GetClients();
			ViewBag.Doctors = _user.GetDoctors();
			ViewBag.Products = _product.GetProducts();
			ViewBag.Services = _service.GetServices();
			ViewBag.Forms = _formsObject;
			return View();
		}

		[HttpGet]
		public JsonResult GetForms(int idMedicalRecord)
		{
			var forms = _formsObject?.Where(data => data.idMedicalRecord == idMedicalRecord).FirstOrDefault();
			return Json(forms);
		}

		[HttpGet]
		public JsonResult GetPetsByIdClient(int idClient) {
			var pets = _pet.GetPetsByClient(idClient);
			return Json(pets);
		}

		[HttpPost]
		public JsonResult CreateForms(FormsObj formsObj)
		{
			formsObj.arrival = DateTime.Now.Date.ToString("yyyy/MM/dd")+" "+formsObj.arrival;

			if (String.IsNullOrEmpty(formsObj.motive))
			{
				formsObj.motive = "";
			}

            if (String.IsNullOrEmpty(formsObj.attention))
            {
				formsObj.attention = "";

            }
			else
			{
                formsObj.attention = DateTime.Now.Date.ToString("yyyy/MM/dd") + " " + formsObj.attention;
            }

            var createForms = _forms.CreateForms(formsObj);
			return Json(createForms);
		}

		[HttpPut]
		public JsonResult UpdateForms(FormsObj formsObj)
		{
            formsObj.arrival = _currentDateTimeZoneInfo.GetCurrentDateTimeZone().ToString("yyyy/MM/dd") + " " + formsObj.arrival;

            if (String.IsNullOrEmpty(formsObj.motive))
            {
                formsObj.motive = "";
            }

            if (String.IsNullOrEmpty(formsObj.attention))
            {
                formsObj.attention = "";

            }
            else
            {
                formsObj.attention = _currentDateTimeZoneInfo.GetCurrentDateTimeZone().ToString("yyyy/MM/dd") + " " + formsObj.attention;
            }

            var updateForms = _forms.UpdateForms(formsObj);
			return Json(updateForms);
		}

		[HttpDelete]
		public JsonResult DeleteForms(int idMedicalRecord)
		{
			var deleteForm = _forms.DeleteForms(idMedicalRecord);
			return Json(deleteForm);
		}

	}
}
