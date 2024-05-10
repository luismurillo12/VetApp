namespace VetApp.Entities
{
    public class AppointmentObj
    {
        public int IdDate { get; set; }
        public int IdClient { get; set; }
        public string DateReason { get; set; } = String.Empty;
        public string DateHour { get; set; } = String.Empty;
        public int IdDoctor { get; set; }
        public string DayDate { get; set; } = String.Empty;
        public string ClientName { get; set; } = String.Empty;
        public string DoctorName { get; set; } = String.Empty;
        public string AppointmentDate { get; set; } = String.Empty;
    }
}
