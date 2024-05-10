using Newtonsoft.Json;
using VetApp.Entities;

namespace VetApp.Models
{
    public class PetModel
    {
		private readonly IConfiguration _configuration;
		private string _urlApi;
		public PetModel(IConfiguration configuration)
        {
			_configuration = configuration;
			_urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
		}

        public int CreatePet(PetObj petObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(petObj);
                string url = _urlApi + "api/Pet/CreatePet";
                HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<PetObj> GetPets()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Pet/GetPets";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<PetObj>>().Result;

                return new List<PetObj>();
            }
        }

        public int UpdatePet(PetObj petObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(petObj);
                string url = _urlApi + "api/Pet/UpdatePet";
                HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int DeletePet(int idPet)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Pet/DeletePet?idPet=" + idPet;
                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

		public List<PetObj> GetPetsByClient(int idClient)
		{

			using (var client = new HttpClient())
			{
				string url = _urlApi + "api/Pet/GetPetsByClient/"+idClient;

				HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<List<PetObj>>().Result;

				return new List<PetObj>();
			}

			//using (var access = new HttpClient())
			//{
			//	HttpResponseMessage response = await access.GetAsync($"https://localhost:7032/api/Pet/GetPetsByClient/{idClient}");
			//	string resultStr = await response.Content.ReadAsStringAsync();
			//	return JsonConvert.DeserializeObject<List<PetObj>>(resultStr) ?? new List<PetObj>();
			//}
		}
	}
}
