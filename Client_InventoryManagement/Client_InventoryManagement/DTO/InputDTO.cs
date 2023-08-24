using System.ComponentModel.DataAnnotations;

namespace Client_InventoryManagement.DTO
{
    public class InputDTO
    {
        [Required]
        public int SupplierId { get; set; }

        [Required]
        public string? Status { get; set; }

        public string? Note { get; set; }
    }

    public class InputResponseDTO
    {
        public string Id { get; set; }
        public DateTime InputDate { get; set; }
        public int SupplierId { get; set; }
        public string StaffId { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}
