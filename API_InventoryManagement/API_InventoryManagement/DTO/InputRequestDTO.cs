﻿using API_InventoryManagement.Data;
using API_InventoryManagement.Models;

namespace API_InventoryManagement.DTO
{
    public class InputRequestDTO
    {
        public int SupplierId { get; set; }
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
