using VetApp.Entities;

namespace VetApp.Models
{
    public class ClientModel
    {
		private readonly IConfiguration _configuration;
		private string _urlApi;
		public ClientModel(IConfiguration configuration) 
        {
			_configuration = configuration;
			_urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
		}

        public int CreateClient(ClientObj clientObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(clientObj);
                string url = _urlApi + "api/Client/CreateClient";
                HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<ClientObj> GetClients()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Client/GetClients";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<ClientObj>>().Result;

                return new List<ClientObj>();
            }
        }


        public int UpdateClient(ClientObj clientObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(clientObj);
                string url = _urlApi + "api/Client/UpdateClient";
                HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int DeleteClient(int idClient)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Client/DeleteClient?idClient=" + idClient;
                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }
    }
}