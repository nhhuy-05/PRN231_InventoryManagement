using API_InventoryManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace API_InventoryManagement.Data
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Inputs = new HashSet<Input>();
            Outputs = new HashSet<Output>();    
        }
        public string? FullName { get; set; }

        public virtual ICollection<Input> Inputs { get; set; } = null!;
        public virtual ICollection<Output> Outputs { get; set; } = null!;
    }
}
