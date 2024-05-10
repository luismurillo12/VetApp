using Newtonsoft.Json;
using VetApp.Entities;

namespace VetApp.Models
{
    public class ProductModel
    {
		private readonly IConfiguration _configuration;
		private string _urlApi;
		public ProductModel(IConfiguration configuration) 
        {
			_configuration = configuration;
			_urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
		}

        public int CreateProduct(ProductObj productObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(productObj);
                string url = _urlApi + "api/Product/CreateProduct";
                HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<ProductObj> GetProducts()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Product/GetProducts";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<ProductObj>>().Result;

                return new List<ProductObj>();
            }
        }


        public int UpdateProduct(ProductObj productObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(productObj);
                string url = _urlApi + "api/Product/UpdateProduct";
                HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int DeleteProduct(int idProduct)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Product/DeleteProduct?idProduct=" + idProduct;
                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

		public List<ProductObj> GetProductsBySupplier(int idSupplier)
		{

			using (var client = new HttpClient())
			{
				string url = _urlApi + "api/Product/GetProductsBySupplier/" + idSupplier;

				HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<List<ProductObj>>().Result;

				return new List<ProductObj>();
			}

		}
	}
}