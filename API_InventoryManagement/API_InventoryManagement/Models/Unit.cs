namespace API_InventoryManagement.Models
{
    public class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Product> Products { get; set; } 

    }
}
