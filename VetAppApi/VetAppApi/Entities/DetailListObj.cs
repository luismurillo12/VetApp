namespace VetAppApi.Entities
{
    public class DetailListObj
    {
        public int idDetail {  get; set; }
        public string nameDetail { get; set; } = string.Empty;
        public string descriptionDetail { get; set; } = string.Empty;
        public int amountDetail {  get; set; }
        public decimal costDetail {  get; set; }
        public int idInvoices {  get; set; }
        public int idCredit {  get; set; }
        public string dateInvoices { get; set; } = string.Empty;
    }
}
