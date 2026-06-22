namespace OrderService.Application.UseCases.Queries.GetOrderById;

public record GetOrderByIdDto(
    Guid Id,
    string OrderNumber,
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal Weight,
    DateTime PickUpDate,
    DateTime CreatedAt);