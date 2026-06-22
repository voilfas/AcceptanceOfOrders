using MediatR;
using OrderService.Domain.Common;

namespace OrderService.Application.UseCases.Commands.CreateOrder;

public record CreateOrderCommand(
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal Weight,
    DateTime PickUpDate) : IRequest<Result<string>>;