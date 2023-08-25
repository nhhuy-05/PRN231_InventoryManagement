namespace Client_InventoryManagement.DTO
{
    public class GetInputPriceAndNumberOfInput
    {
        public decimal TotalInputPrice { get; set; }
        public int NumberOfInputsThisMonth { get; set; }
    }

    public class GetOutputPriceAndNumberOfOutput
    {
        public decimal TotalOutputPrice { get; set; }
        public int NumberOfOutputsThisMonth { get; set; }
    }

    public class GetNumberOfCustomerAndSupplier
    {
        public int NumberOfCustomers { get; set; }
        public int NumberOfSuppliers { get; set; }
    }

    public class GetNumberOfProduct
    {
        public int NumberOfProducts { get; set; }
    }
}
