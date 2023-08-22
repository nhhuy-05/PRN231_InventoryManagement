namespace API_InventoryManagement.DTO
{
    public class SupplierRequestDTO
    {
        public string SupplierName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? ContractDate { get; set; }
    }
}
