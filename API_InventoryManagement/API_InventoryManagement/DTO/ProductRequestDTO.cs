﻿namespace API_InventoryManagement.DTO
{
    public class ProductRequestDTO
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public int? SupplierId { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }

    }
}