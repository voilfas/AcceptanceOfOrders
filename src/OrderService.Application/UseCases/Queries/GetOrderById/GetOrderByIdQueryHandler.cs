using MediatR;
using OrderService.Application.Errors;
using OrderService.Application.Interfaces;
using OrderService.Domain.Common;
using OrderService.Domain.Errors;

namespace OrderService.Application.UseCases.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdDto>>
{
    private readonly IOrderRepository _repository;

    public GetOrderByIdQueryHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<GetOrderByIdDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.OrderId, cancellationToken);
        
        if (order == null)
            return Result<GetOrderByIdDto>.Failure(ApplicationErrors.OrderNotFoundById);

        var orderDto = new GetOrderByIdDto(
            order.Id,
            order.OrderNumber,
            order.SenderCity,
            order.SenderAddress,
            order.ReceiverCity,
            order.ReceiverAddress,
            order.Weight,
            order.PickUpDate,
            order.CreatedAt);
        
        return Result<GetOrderByIdDto>.Success(orderDto);
    }
}