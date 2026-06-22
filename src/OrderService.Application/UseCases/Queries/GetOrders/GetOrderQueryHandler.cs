using MediatR;
using OrderService.Application.Interfaces;
using OrderService.Domain.Common;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.Queries.GetOrders;

public class GetOrderQueryHandler : IRequestHandler<GetOrdersQuery, Result<List<OrderListItemDto>>>
{
    private readonly IOrderRepository _repository;

    public GetOrderQueryHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<List<OrderListItemDto>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var listOrder = await _repository.GetAllAsync(cancellationToken);
        
        var listOrderDto = listOrder
            .Select(order => new OrderListItemDto(
                order.Id,
                order.OrderNumber,
                order.SenderCity,
                order.SenderAddress,
                order.ReceiverCity,
                order.ReceiverAddress,
                order.Weight,
                order.PickUpDate)).ToList();
        
        return Result<List<OrderListItemDto>>.Success(listOrderDto);
    }
}