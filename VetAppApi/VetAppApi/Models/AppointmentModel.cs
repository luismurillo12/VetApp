using System.Data.SqlClient;
using System.Data;
using VetAppApi.Entities;
using VetAppApi.Services;
using Dapper;

namespace VetAppApi.Models
{
	public class AppointmentModel
	{
		private readonly IConfiguration _configuration;
		private readonly CurrentDateTimeZoneInfo _currentDateTimeZoneInfo;
		public AppointmentModel(IConfiguration configuration)
		{
			_configuration = configuration;
			_currentDateTimeZoneInfo = new CurrentDateTimeZoneInfo();
		}

		public int ScheduleAppointment(AppointmentObj appointmentObj)
		{
			try
			{

				using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
				{
					var datos = connection.Execute("SP_ScheduleAppointment",
						new
						{
							appointmentObj.IdClient
							,
							appointmentObj.DateReason
							,
							appointmentObj.DateHour
							,
							appointmentObj.IdDoctor

						},
						commandType: CommandType.StoredProcedure);

					return datos;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return 0;
		}

		public int UpdateAppointment(AppointmentObj appointmentObj)
		{
			try
			{

				using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
				{
					var datos = connection.Execute("SP_UpdateAppointment",
						new
						{
							appointmentObj.IdDate
						    ,   
							appointmentObj.IdClient
							,
							appointmentObj.DateReason
							,
							appointmentObj.DateHour
							,
							appointmentObj.IdDoctor

						},
						commandType: CommandType.StoredProcedure);

					return datos;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return 0;
		}

		public int DeleteAppointment(int idDate)
		{
			try
			{

				using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
				{
					var datos = connection.Execute("SP_DeleteAppointment",
						new
						{
							idDate

						},
						commandType: CommandType.StoredProcedure);

					return datos;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return 0;
		}

		public IEnumerable<AppointmentObj> GetAppointmentsByDay()
		{

			try
			{
				var currentDate = _currentDateTimeZoneInfo.GetCurrentDateTimeZone();

				using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
				{
					var datos = connection.Query<AppointmentObj>("SP_GetAppointmentsByDay", new { currentDate },
						commandType: CommandType.StoredProcedure).ToList();

					return datos;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return new List<AppointmentObj>();
		}

		public IEnumerable<AppointmentObj> GetAppointments()
		{

			try
			{
				using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
				{
					var datos = connection.Query<AppointmentObj>("SP_GetAppointments", null,
						commandType: CommandType.StoredProcedure).ToList();

					return datos;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return new List<AppointmentObj>();
		}
	}
}
