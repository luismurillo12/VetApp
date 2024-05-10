using VetApp.Entities;

namespace VetApp.Models
{
    public class ServiceModel
    {
		private readonly IConfiguration _configuration;
		private string _urlApi;
		public ServiceModel(IConfiguration configuration) 
        {
			_configuration = configuration;
			_urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
		}

        public int CreateService(ServiceObj serviceObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(serviceObj);
                string url = _urlApi + "api/Service/CreateService";
                HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<ServiceObj> GetServices()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Service/GetServices";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<ServiceObj>>().Result;

                return new List<ServiceObj>();
            }
        }


        public int UpdateService(ServiceObj serviceObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(serviceObj);
                string url = _urlApi + "api/Service/UpdateService";
                HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int DeleteService(int idService)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi +"api/Service/DeleteService?idService=" + idService;
                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }
    }
}