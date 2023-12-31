﻿namespace API_InventoryManagement.DTO
{
    public class InputDetailRequestDTO
    {
        public string InputId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiredDate { get; set; }
        public decimal InputPrice { get; set; }
    }
}
