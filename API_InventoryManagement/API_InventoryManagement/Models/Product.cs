namespace API_InventoryManagement.Models
{
    public class Product
    {
        public Product()
        {
            InputDetails = new HashSet<InputDetail>();
            OutputDetails = new HashSet<OutputDetail>();
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public int? SupplierId { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Unit Unit { get; set; } = null!;
        public virtual Supplier? Supplier { get; set; } = null!;

        public virtual ICollection<InputDetail> InputDetails { get; set; } = null!;
        public virtual ICollection<OutputDetail> OutputDetails { get; set; } = null!;
    }
}
