using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VetApp.Entities;
using VetApp.Models;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class ReportesController : Controller
    {
		private readonly ReportsModel _reportsModel;
		private readonly PaymentModel _paymentModel;
		private readonly IConfiguration _configuration;

		public ReportesController(IConfiguration configuration)
		{
			_configuration = configuration;
			_reportsModel = new ReportsModel(_configuration);
			_paymentModel = new PaymentModel(_configuration);

		}

		public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReporteCitas()
        {
            return View();
        }

		[HttpPost]
		public IActionResult ReporteCitas(string startDate, string endDate)
		{

			if(String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate)){
				ViewBag.Message = "Debe de seleccionar la fecha de inicio.";
				return View();
			}

            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de fin.";
                return View();
            }

            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de inicio y la fecha de fin del reporte.";
                return View();
            }

            ViewBag.AppointmentReport = _reportsModel.AppointmentsReport(startDate, endDate);
			
			return View();
		}

		[HttpGet]
		public IActionResult ReportePlanilla()
        {
            return View();
        }


		[HttpPost]
		public IActionResult ReportePlanilla(string startDate, string endDate)
		{

            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de inicio.";
                return View();
            }

            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de fin.";
                return View();
            }

            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de inicio y la fecha de fin del reporte.";
                return View();
            }

            ViewBag.FormReport = _reportsModel.FormsReport(startDate, endDate);

			return View();
		}

		[HttpGet]
		public IActionResult ReporteTransacciones()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ReporteTransacciones(string startDate, string endDate)
        {
            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de inicio.";
                return View();
            }

            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de fin.";
                return View();
            }

            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de inicio y la fecha de fin del reporte.";
                return View();
            }

            ViewBag.TransactionsReport = _paymentModel.GetInvoices(startDate, endDate);

			return View();
		}

		[HttpGet]
		public JsonResult GetDetailByIdInvoices(int idInvoice)
		{
			var response = _paymentModel.GetDetailByIdInvoices(idInvoice);

			return Json(response);
		}

		[HttpGet]
		public IActionResult ReporteCreditos()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ReporteCreditos(string startDate, string endDate)
		{
            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de inicio.";
                return View();
            }

            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de fin.";
                return View();
            }

            if (String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate))
            {
                ViewBag.Message = "Debe de seleccionar la fecha de inicio y la fecha de fin del reporte.";
                return View();
            }

            ViewBag.TransactionsReport = _reportsModel.GetCreditsReport(startDate, endDate);

			return View();
		}

		[HttpGet]
		public JsonResult GetDepositsCreditsByIdClient(int idClient)
		{
			var response = _paymentModel.GetDepositsCreditsByIdClient(idClient);

			return Json(response);
		}
	}
}
