namespace VetAppApi.Entities
{
    public class ProductObj
    {

        public int idProduct{ get; set; } = 0;
        public int idSupplier { get; set; } = 0;
        public string product{ get; set; } = string.Empty;
        public double productBuyCost{ get; set; } = 0;
        public double productSellCost { get; set; } = 0;

    }
}
