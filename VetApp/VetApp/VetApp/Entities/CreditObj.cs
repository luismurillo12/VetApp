namespace VetApp.Entities
{
    public class CreditObj
    {
        public int IdCredit { get; set; }
        public string DateCredit { get; set; } = string.Empty;
        public decimal TotalBalance { get; set; }
        public decimal TotalCredit { get; set; }
        public bool statusP {  get; set; }
    }
}
