namespace Domain
{
    public class FlowerService
    {
        private readonly IDeliveryService _deliveryService;

        public FlowerService(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        public SendResponse Send(Order order)
        {
            return _deliveryService.SendFlowers(order);
        }
    }

    public class SendResponse
    {
        public bool WasSuccessfull { get; set; }
    }

    public class Order
    {
        public string From { get; set; }
        public string To { get; set; }
        public string FlowerName { get; set; }
    }

    public interface IDeliveryService
    {
        SendResponse SendFlowers(Order order);
    }
}
