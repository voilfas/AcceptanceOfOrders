using MediatR;
using OrderService.Application.Interfaces;
using OrderService.Domain.Common;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<string>>
{
    private readonly IOrderRepository _repository;

    public CreateOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var pickUpDateUtc = DateTime.SpecifyKind(request.PickUpDate, DateTimeKind.Utc);
        
        var resultOrder = Order.Create(
            request.SenderCity,
            request.SenderAddress,
            request.ReceiverCity,
            request.ReceiverAddress,
            request.Weight,
            pickUpDateUtc);

        if (resultOrder.IsFailure)
            return Result<string>.Failure(resultOrder.Error);
        
        var order = resultOrder.Value!;
        
        await _repository.AddAsync(order, cancellationToken);
        await _repository.SaveAsync(cancellationToken);
        
        return Result<string>.Success(order.OrderNumber);
    }
}