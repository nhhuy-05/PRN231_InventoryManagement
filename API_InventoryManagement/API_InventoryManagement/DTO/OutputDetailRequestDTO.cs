namespace API_InventoryManagement.DTO
{
    public class OutputDetailRequestDTO
    {
        public string OutputId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string InputId { get; set; }
        public decimal OutputPrice { get; set; }
    }
}
