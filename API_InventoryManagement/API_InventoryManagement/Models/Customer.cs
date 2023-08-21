namespace API_InventoryManagement.Models
{
    public class Customer
    {
        public Customer()
        {
            Outputs = new HashSet<Output>();
        }
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? ContractDate { get; set; }

        public virtual ICollection<Output> Outputs { get; set; }
    }
}
