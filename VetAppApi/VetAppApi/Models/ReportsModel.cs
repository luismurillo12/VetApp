using System.Data.SqlClient;
using System.Data;
using VetAppApi.Entities;
using Dapper;

namespace VetAppApi.Models
{
	public class ReportsModel
	{
		private readonly IConfiguration _configuration;

		public ReportsModel(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IEnumerable<AppointmentObj> AppointmentsReport(string startDate, string endDate)
		{

			try
			{
				using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
				{
					var datos = connection.Query<AppointmentObj>("SP_AppointmentsReport", new
					{
						startDate,
						endDate
					},
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

		public IEnumerable<FormsListObj> FormsReport(string startDate, string endDate)
		{

			try
			{
				using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
				{
					var datos = connection.Query<FormsListObj>("SP_FormsReport", new
					{
						startDate,
						endDate
					},
						commandType: CommandType.StoredProcedure).ToList();

					return datos;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return new List<FormsListObj>();
		}

        public IEnumerable<CreditListObj> GetCreditsReport(string startDate, string @endDate)
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<CreditListObj>("SP_GetCreditsReport", new { startDate, @endDate },
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<CreditListObj>();
        }
    }
}
