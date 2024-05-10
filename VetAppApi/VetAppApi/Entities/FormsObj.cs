namespace VetAppApi.Entities
{
    public class FormsObj
    {
        public int idMedicalRecord { get; set; }
        public int idUser { get; set; } = 0;
        public int idPet { get; set; } = 0;
        public int idClient { get; set; } = 0;
		public string motive { get; set; } = string.Empty;
        public string arrival { get; set; } = string.Empty;
		public string attention { get; set; } = string.Empty;
		public int idProduct { get; set; } = 0;
		public int idService { get; set; } = 0;
        public bool statusP {  get; set; }
    }
}
