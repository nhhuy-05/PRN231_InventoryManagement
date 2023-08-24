using API_InventoryManagement.Data;
using API_InventoryManagement.Models;

namespace API_InventoryManagement.DTO
{
    public class InputRequestDTO
    {
        public int SupplierId { get; set; }
        public string? Status { get; set; }
        public string? Note { get; set; }

    }
}
