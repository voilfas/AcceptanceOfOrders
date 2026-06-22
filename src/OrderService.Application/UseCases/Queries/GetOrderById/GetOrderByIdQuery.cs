using MediatR;
using OrderService.Domain.Common;

namespace OrderService.Application.UseCases.Queries.GetOrderById;

public record GetOrderByIdQuery(Guid OrderId) : IRequest<Result<GetOrderByIdDto>>;