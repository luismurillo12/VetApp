namespace VetAppApi.Entities
{
	public class FormsListObj
	{
		public int idMedicalRecord { get; set; }
		public string doctorName { get; set; } = string.Empty;
		public string petName { get; set; } = string.Empty;
		public string petSpecies { get; set; } = string.Empty;
		public string clientIdCard { get; set; } = string.Empty;
		public string motive { get; set; } = string.Empty;
		public string arrival { get; set; } = string.Empty;
		public string attention { get; set; } = string.Empty;
		public string product { get; set; } = string.Empty;
		public string serviceName { get; set; } = string.Empty;
		public bool statusP { get; set; }
		public int idDoctor { get; set; } = 0;
		public int idPet { get; set; } = 0;
		public int idClient { get; set; } = 0;
        public string arrivalHour { get; set; } = string.Empty;
        public string attentionHour { get; set; } = string.Empty;
        public int idProduct { get; set; } = 0;
        public int idService { get; set; } = 0;
    }
}
