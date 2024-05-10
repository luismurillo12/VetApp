using VetApp.Entities;

namespace VetApp.Models
{
    public class PaymentModel
    {
        private readonly IConfiguration _configuration;
        private string _urlApi;
        public PaymentModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
        }

        public List<PaymentTypeObj>? GetPaymentType()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/GetPaymentType";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<PaymentTypeObj>>().Result;

                return new List<PaymentTypeObj>();
            }
        }

        public int CreateInvoices(InvoicesObj invoicesObj)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/CreateInvoices";

                var data = JsonContent.Create(invoicesObj);

                HttpResponseMessage response = client.PostAsync(url,data).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<InvoicesListObj>? GetInvoices(string startDate, string endDate)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/GetInvoices?startDate="+startDate+"&endDate="+endDate+"";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<InvoicesListObj>>().Result;

                return new List<InvoicesListObj>();
            }
        }

        public List<DetailInvoicesObj>? GetDetail()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/GetDetail";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<DetailInvoicesObj>>().Result;

                return new List<DetailInvoicesObj>();
            }
        }

        public List<CreditListObj>? GetCredits(int idClient)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/GetCredits?idClient=" + idClient;

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<CreditListObj>>().Result;

                return new List<CreditListObj>();
            }
        }

        public List<DetailListObj>? GetDetailByIdInvoices(int idInvoice)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/GetDetailByIdInvoices?idInvoice=" + idInvoice;

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<DetailListObj>>().Result;

                return new List<DetailListObj>();
            }
        }

        public List<CreditListObj>? GetDepositsCreditsByIdClient(int idClient)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/GetDepositsCreditsByIdClient?idClient=" + idClient;

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<CreditListObj>>().Result;

                return new List<CreditListObj>();
            }
        }
    }
}
