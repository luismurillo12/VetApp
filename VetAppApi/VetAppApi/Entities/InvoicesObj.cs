namespace VetAppApi.Entities
{
    public class InvoicesObj
    {
        public int idInvoices { get; set; } = 0;
        public long numReference { get; set; }
        public string dateInvoices { get; set; } = string.Empty;
        public decimal totalCancel { get; set; }
        public decimal totalCanceled { get; set; }
        public int idPaymentType { get; set; }
        public int idClient { get; set; }
        public int invoiceType { get; set; }
        public List<DetailObj>? DetailInvoices { get; set; }
        public CreditObj? Credit { get; set; }
    }
}
