using API_InventoryManagement.Data;
using Microsoft.AspNetCore.Identity;

namespace API_InventoryManagement.Models
{
    public class Output
    {
        public string Id { get; set; }
        public DateTime OutputDate { get; set; }
        public int CustomerId { get; set; }
        public string StaffId { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
        public virtual ICollection<OutputDetail> OutputDetails { get; set; } = null!;
    }
}
