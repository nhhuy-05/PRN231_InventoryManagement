using API_InventoryManagement.Data;
using Microsoft.AspNetCore.Identity;

namespace API_InventoryManagement.Models
{
    public class Input
    {
        public string Id { get; set; }
        public DateTime InputDate { get; set; }
        public int SupplierId { get; set; }
        public string StaffId { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        public virtual Supplier? Supplier { get; set; } = null!;
        public virtual AppUser? User { get; set; } = null!;
        public virtual ICollection<InputDetail>? InputDetails { get; set; } = null!;

    }
}
