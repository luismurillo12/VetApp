namespace VetApp.Entities
{
    public class InvoicesListObj
    {
        public int idInvoices { get; set; } = 0;
        public long numReference { get; set; }
        public string dateInvoices { get; set; } = string.Empty;
        public decimal totalCancel { get; set; }
        public decimal totalCanceled { get; set; }
        public string paymentName { get; set; } = string.Empty;
        public string clientName { get; set; } = string.Empty;
        public int idCredit { get; set; }
    }
}
