using VetApp.Entities;

namespace VetApp.Models
{
    public class AppointmentModel
    {
        private readonly IConfiguration _configuration;
        private string _urlApi;
        public AppointmentModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
        }

        public int ScheduleAppointment(AppointmentObj appointmentObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(appointmentObj);
                string url = _urlApi + "api/Appointment/ScheduleAppointment";
                HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int UpdateAppointment(AppointmentObj appointmentObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(appointmentObj);
                string url = _urlApi + "api/Appointment/UpdateAppointment";
                HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int DeleteAppointment(int idDate)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Appointment/DeleteAppointment?idDate="+idDate;
                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<AppointmentObj>? GetAppointmentsByDay()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Appointment/GetAppointmentsByDay";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<AppointmentObj>>().Result;

                return new List<AppointmentObj>();
            }
        }

        public List<AppointmentObj>? GetAppointments()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Appointment/GetAppointments";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<AppointmentObj>>().Result;

                return new List<AppointmentObj>();
            }
        }
    }
}
