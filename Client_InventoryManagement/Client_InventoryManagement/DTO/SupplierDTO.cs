namespace Client_InventoryManagement.DTO
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string SupplierName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? ContractDate { get; set; }
    }
    public class SupplierRequestDTO
    {
        //public int Id { get; set; }
        public string SupplierName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        //public DateTime? ContractDate { get; set; }
    }
}
