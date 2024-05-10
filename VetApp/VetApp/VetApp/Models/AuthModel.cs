using VetApp.Entities;

namespace VetApp.Models
{
    public class AuthModel
    {

		private readonly IConfiguration _configuration;
		private string _urlApi;
		public string? lblmsj { get; set; }

		public AuthModel(IConfiguration configuration)
		{
			_configuration = configuration;
			_urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
		}

		public UserObj? Login(UserObj userObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = _urlApi + "api/Auth/Login";
                JsonContent content = JsonContent.Create(userObj);
                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();
                return (response.IsSuccessStatusCode) ? response.Content.ReadFromJsonAsync<UserObj>().Result : null;
            }
        }

		public string RequestNewPasswordEmailSend(UserObj userObj)
		{
			using (var client = new HttpClient())
			{
				JsonContent body = JsonContent.Create(userObj);
				string url = _urlApi + "api/Auth/RequestNewPasswordEmailSend";
				HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadAsStringAsync().Result;

				return String.Empty;
			}
		}
	}
}
