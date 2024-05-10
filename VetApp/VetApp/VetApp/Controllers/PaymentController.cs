
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Drawing;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using VetApp.Services;

namespace VetApp.Controllers
{

    [ResponseCache(NoStore = true, Duration = 0)]
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ServiceModel _service;
        private readonly PaymentModel _paymentModel;
        public List<ServiceObj> _servicesObject;
        private readonly ProductModel _productModel;
        public List<ProductObj> _productsList;
        private readonly ClientModel _clientModel;
        public List<ClientObj> _clientList;

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
            _paymentModel = new PaymentModel(configuration);
            _service = new ServiceModel(configuration);
            _servicesObject = _service.GetServices();
            _productModel = new ProductModel(configuration);
            _productsList = _productModel.GetProducts();
            _clientModel = new ClientModel(configuration);
            _clientList = _clientModel.GetClients();

        }

        [HttpGet]
		[FilterSecurity]
		public IActionResult Payment()
        {

            ViewBag.Services = _servicesObject;
            ViewBag.Products = _productsList;
            ViewBag.Clients = _clientList;
            ViewBag.PaymentTypes = _paymentModel.GetPaymentType();
            return View();
        }

        [HttpPost]
		[FilterSecurity]
		public JsonResult CreateInvoices(InvoicesObj invoicesObj)
        {
            if(invoicesObj.DetailInvoices != null)
            {
                foreach (var details in invoicesObj.DetailInvoices.ToList())
                {
                    if (String.IsNullOrEmpty(details.descriptionDetail))
                    {
                        details.descriptionDetail = "";
                    }
                }
            }

            var create = _paymentModel.CreateInvoices(invoicesObj);

            return Json(create);
        }

        [HttpGet]
        [FilterSecurity]
        public JsonResult GetCreditsByIdClient(int idClient)
        {
            var response = _paymentModel.GetCredits(idClient);

            return Json(response);
        }
    }
}









