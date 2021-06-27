namespace ProductManagement.MessageContracts.Commands
{
    public interface IProductRegistrationCommand
    {
         string ProductName { get; set; }
         int Quantity { get; set; }
    }
}