using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportsController : ControllerBase
	{
		private ReportsModel _reportsModel;

		public ReportsController(ReportsModel reportsModel)
		{
			_reportsModel = reportsModel;
		}

		[HttpGet]
		[Route("AppointmentsReport")]
		public ActionResult<IEnumerable<AppointmentObj>> AppointmentsReport(string startDate, string endDate)
		{
			return _reportsModel.AppointmentsReport(startDate,endDate).ToList();
		}

		[HttpGet]
		[Route("FormsReport")]
		public ActionResult<IEnumerable<FormsListObj>> FormsReport(string startDate, string endDate)
		{
			return _reportsModel.FormsReport(startDate, endDate).ToList();
		}


        [HttpGet]
        [Route("GetCreditsReport")]
        public ActionResult<IEnumerable<CreditListObj>> GetCreditsReport(string startDate, string endDate)
        {
            return _reportsModel.GetCreditsReport(startDate, endDate).ToList();
        }

    }
}
