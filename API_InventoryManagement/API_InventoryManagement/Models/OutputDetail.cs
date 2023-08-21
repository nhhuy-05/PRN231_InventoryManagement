namespace API_InventoryManagement.Models
{
    public class OutputDetail
    {
        public string OutputId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal OutputPrice { get; set; }
        public virtual Output Output { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
