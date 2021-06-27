namespace ProductManagement.MessageContracts.Events
{
    public interface IProductRegisteredEvent
    {
         string ProductName { get; set; }
         int Quantity { get; set; }
    }
}