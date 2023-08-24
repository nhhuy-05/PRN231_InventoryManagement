namespace API_InventoryManagement.Models
{
    public class InputDetail
    {
        public string InputId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal InputPrice { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime ExpiredDate { get; set; }
        public virtual Input Input { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
