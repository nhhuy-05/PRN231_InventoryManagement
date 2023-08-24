namespace Client_InventoryManagement.DTO
{
    public class OutputDTO
    {
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }

    public class OutputResponseDTO
    {
        public string Id { get; set; }
        public DateTime OutputDate { get; set; }
        public int CustomerId { get; set; }
        public string StaffId { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}
