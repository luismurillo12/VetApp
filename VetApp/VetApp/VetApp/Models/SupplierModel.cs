using VetApp.Entities;

namespace VetApp.Models
{
    public class SupplierModel
    {
		private readonly IConfiguration _configuration;
		private string _urlApi;
		public SupplierModel(IConfiguration configuration) 
        {
			_configuration = configuration;
			_urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
		}

        public int CreateSupplier(SupplierObj supplierObj)
        {
            using (var supplier = new HttpClient())
            {
                JsonContent body = JsonContent.Create(supplierObj);
                string url = _urlApi + "api/Supplier/CreateSupplier";
                HttpResponseMessage response = supplier.PostAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<SupplierObj> GetSuppliers()
        {
            using (var supplier = new HttpClient())
            {
                string url = _urlApi + "api/Supplier/GetSuppliers";

                HttpResponseMessage response = supplier.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<SupplierObj>>().Result;

                return new List<SupplierObj>();
            }
        }


        public int UpdateSupplier(SupplierObj supplierObj)
        {
            using (var supplier = new HttpClient())
            {
                JsonContent body = JsonContent.Create(supplierObj);
                string url = _urlApi + "api/Supplier/UpdateSupplier";
                HttpResponseMessage response = supplier.PutAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int DeleteSupplier(int idSupplier)
        {
            using (var supplier = new HttpClient())
            {
                string url = _urlApi + "api/Supplier/DeleteSupplier?idSupplier=" + idSupplier;
                HttpResponseMessage response = supplier.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }
    }
}