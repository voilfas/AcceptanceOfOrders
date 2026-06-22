using MediatR;
using OrderService.Domain.Common;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.Queries.GetOrders;

public record GetOrdersQuery() : IRequest<Result<List<OrderListItemDto>>>;