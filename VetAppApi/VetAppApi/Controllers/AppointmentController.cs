using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentController : ControllerBase
	{
		private AppointmentModel _appointmentModel;

		public AppointmentController(AppointmentModel appointmentModel)
		{
			_appointmentModel = appointmentModel;
		}

		[HttpPost]
		[Route("ScheduleAppointment")]
		public ActionResult<int> ScheduleAppointment(AppointmentObj appointmentObj)
		{
			return _appointmentModel.ScheduleAppointment(appointmentObj);
		}

		[HttpPut]
		[Route("UpdateAppointment")]
		public ActionResult<int> UpdateAppointment(AppointmentObj appointmentObj)
		{
			return _appointmentModel.UpdateAppointment(appointmentObj);
		}

		[HttpDelete]
		[Route("DeleteAppointment")]
		public ActionResult<int> DeleteAppointment(int idDate)
		{
			return _appointmentModel.DeleteAppointment(idDate);
		}

		[HttpGet]
		[Route("GetAppointmentsByDay")]
		public ActionResult<IEnumerable<AppointmentObj>> GetAppointmentsByDay()
		{
			return _appointmentModel.GetAppointmentsByDay().ToList();
		}

		[HttpGet]
		[Route("GetAppointments")]
		public ActionResult<IEnumerable<AppointmentObj>> GetAppointments()
		{
			return _appointmentModel.GetAppointments().ToList();
		}
	}
}
