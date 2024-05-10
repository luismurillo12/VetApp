using VetApp.Entities;

namespace VetApp.Models
{
	public class ReportsModel
	{
		private readonly IConfiguration _configuration;
		private string _urlApi;
		public ReportsModel(IConfiguration configuration)
		{
			_configuration = configuration;
			_urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
		}

		public List<AppointmentObj>? AppointmentsReport(string startDate, string endDate)
		{
			using (var client = new HttpClient())
			{
				string url = _urlApi + "api/Reports/AppointmentsReport?startDate="+startDate+"&endDate=" + endDate;

				HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<List<AppointmentObj>>().Result;

				return new List<AppointmentObj>();
			}
		}

		public List<FormsListObj>? FormsReport(string startDate, string endDate)
		{
			using (var client = new HttpClient())
			{
				string url = _urlApi + "api/Reports/FormsReport?startDate=" + startDate + "&endDate=" + endDate;

				HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<List<FormsListObj>>().Result;

				return new List<FormsListObj>();
			}
		}

        public List<CreditListObj>? GetCreditsReport(string startDate, string endDate)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Reports/GetCreditsReport?startDate=" + startDate + "&endDate=" + endDate;

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<CreditListObj>>().Result;

                return new List<CreditListObj>();
            }
        }
    }
}
