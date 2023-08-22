using System.ComponentModel.DataAnnotations;

namespace Client_InventoryManagement.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
    }
}
