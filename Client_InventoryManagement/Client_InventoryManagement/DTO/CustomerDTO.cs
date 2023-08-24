namespace Client_InventoryManagement.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? ContractDate { get; set; }
    }
    public class CustomerRequestDTO
    {
        public string CustomerName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? ContractDate { get; set; }
    }
}
