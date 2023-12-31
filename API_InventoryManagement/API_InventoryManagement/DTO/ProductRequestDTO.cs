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
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }
        public string? SupplierName { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
    }
}
