using VetApp.Entities;

namespace VetApp.Models
{
    public class RoleModel
    {
        private readonly IConfiguration _configuration;
        private string _urlApi;
        public RoleModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
        }

        public List<RoleObj>? GetRoles()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Role/GetRoles";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<RoleObj>>().Result;

                return new List<RoleObj>();
            }
        }
    }
}
