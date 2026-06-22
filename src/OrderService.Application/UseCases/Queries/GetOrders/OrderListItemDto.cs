namespace OrderService.Application.UseCases.Queries.GetOrders;

public record OrderListItemDto(
    Guid OrderId,
    string OrderNumber,
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal Weight,
    DateTime PickUpDate);