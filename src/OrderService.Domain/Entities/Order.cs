using OrderService.Domain.Common;
using OrderService.Domain.Errors;

namespace OrderService.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public string OrderNumber { get; private set; }
    public string SenderCity { get; private set; }
    public string SenderAddress { get; private set; }
    public string ReceiverCity { get; private set; }
    public string ReceiverAddress { get; private set; }
    public decimal Weight { get; private set; }
    public DateTime PickUpDate { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Order(){}
    
    private Order(
        string senderCity, 
        string senderAddress, 
        string receiverCity, 
        string receiverAddress, 
        decimal weight, 
        DateTime pickUpDate)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        OrderNumber = $"ORD-{CreatedAt:yyMMdd}-{Id:N}"[..22];
        SenderCity = senderCity;
        SenderAddress = senderAddress;
        ReceiverCity = receiverCity;
        ReceiverAddress = receiverAddress;
        Weight = weight;
        PickUpDate = pickUpDate;
    }

    public static Result<Order> Create(
        string senderCity, 
        string senderAddress, 
        string receiverCity, 
        string receiverAddress, 
        decimal weight, 
        DateTime pickUpDate)
    {
        if (string.IsNullOrWhiteSpace(senderCity) || senderCity.Length is < 1 or > 168)
            return Result<Order>.Failure(OrderErrors.InvalidCityName);

        if (string.IsNullOrWhiteSpace(senderAddress) || senderAddress.Length is < 4 or > 100)
            return Result<Order>.Failure(OrderErrors.InvalidAddressName);
        
        if (string.IsNullOrWhiteSpace(receiverCity) || receiverCity.Length is < 1 or > 168)
            return Result<Order>.Failure(OrderErrors.InvalidCityName);

        if (string.IsNullOrWhiteSpace(receiverAddress) || receiverAddress.Length is < 4 or > 100)
            return Result<Order>.Failure(OrderErrors.InvalidAddressName);

        if (weight is <= 0.0m or > 1500.0m)
            return Result<Order>.Failure(OrderErrors.InvalidWeight);

        if (pickUpDate < DateTime.UtcNow)
            return Result<Order>.Failure(OrderErrors.InvalidPickUpDate);

        return Result<Order>.Success(new Order(senderCity, senderAddress, receiverCity, receiverAddress, weight, pickUpDate));
    }
}