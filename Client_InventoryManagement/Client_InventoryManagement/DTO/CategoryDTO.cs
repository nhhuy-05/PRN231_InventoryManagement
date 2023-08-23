namespace Client_InventoryManagement.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        public byte[]? Picture { get; set; }
    }

    public class CategoryRequestDTO
    {
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        //public byte[]? Picture { get; set; }
    }
}
