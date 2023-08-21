namespace API_InventoryManagement.Models
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string SupplierName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? ContractDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Input> Inputs { get; set; }

    }
}
