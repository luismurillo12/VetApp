using Newtonsoft.Json;
using VetApp.Entities;

namespace VetApp.Models
{
	public class FormsModel
	{
		private readonly IConfiguration _configuration;
		private string _urlApi;
		public FormsModel(IConfiguration configuration)
		{
			_configuration = configuration;
			_urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
		}

		public int CreateForms(FormsObj formsObj)
		{
			using (var client = new HttpClient())
			{
				JsonContent body = JsonContent.Create(formsObj);
				string url = _urlApi + "api/Forms/CreateForms";
				HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<int>().Result;

				return 0;
			}
		}

		public List<FormsListObj>? GetFormsForCurrentDay()
		{
			using (var client = new HttpClient())
			{
				string url = _urlApi + "api/Forms/GetFormsForCurrentDay";

				HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<List<FormsListObj>>().Result;

				return new List<FormsListObj>();
			}
		}

        public List<FormsListObj>? GetForms()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Forms/GetForms";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<FormsListObj>>().Result;

                return new List<FormsListObj>();
            }
        }

        public int UpdateForms(FormsObj formsObj)
		{
			using (var client = new HttpClient())
			{
				JsonContent body = JsonContent.Create(formsObj);
				string url = _urlApi + "api/Forms/UpdateForms";
				HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<int>().Result;

				return 0;
			}
		}

		public int DeleteForms(int idMedicalRecord)
		{
			using (var client = new HttpClient())
			{
				string url = _urlApi + "api/Forms/DeleteForms?idForms=" + idMedicalRecord;
				HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<int>().Result;

				return 0;
			}
		}



	}
}