namespace VetApp.Entities
{
    public class DetailInvoicesObj
    {
        public int idDetail { get; set; }
        public string? nameDetail { get; set; }
        public string? descriptionDetail { get; set; }
        public int amountDetail { get; set; }
        public decimal costDetail { get; set; }
        public int idInvoices { get; set; }
    }
}
