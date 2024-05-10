namespace VetAppApi.Entities
{
    public class CreditListObj
    {
        public int idCredit {  get; set; }
        public string dateCredit {  get; set; } = string.Empty;
        public decimal totalCredit {  get; set; }
        public decimal totalBalance { get; set; }
        public string statusP { get; set; } = string.Empty;
        public string clientName { get; set; } = string.Empty;
        public int idInvoices {  get; set; }
        public long numReference {  get; set; }
        public string dateInvoices { get; set; } = string.Empty;
        public decimal totalCancel {  get; set; }
        public decimal totalCanceled {  get; set; }
        public string paymentName {  get; set; } = string.Empty;
		public int idClient { get; set; }

	}
}
