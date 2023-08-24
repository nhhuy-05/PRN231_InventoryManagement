namespace Client_InventoryManagement.DTO
{
    public class InputDetailDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal InputPrice { get; set; }
        public DateTime ExpiredDate { get; set; }
    }

    public class InputDetailRequestDTO
    {
        public string InputId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiredDate { get; set; }
        public decimal InputPrice { get; set; }
    }
}
