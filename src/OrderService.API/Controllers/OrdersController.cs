using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.API.Common;
using OrderService.Application.UseCases.Commands.CreateOrder;
using OrderService.Application.UseCases.Queries.GetOrderById;
using OrderService.Application.UseCases.Queries.GetOrders;

namespace OrderService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController: ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command, CancellationToken token)
    {
        var resultOrder = await _mediator.Send(command, token);
        if (resultOrder.IsFailure)
            return StatusCode(ErrorMapper.GetStatusCode(resultOrder.Error), resultOrder.Error);
        
        return Ok(resultOrder.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderById(Guid id, CancellationToken token)
    {
        var resultOrderDto = await _mediator.Send(new GetOrderByIdQuery(id), token);
        
        if (resultOrderDto.IsFailure)
            return StatusCode(ErrorMapper.GetStatusCode(resultOrderDto.Error), resultOrderDto.Error);
        
        return Ok(resultOrderDto.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders(CancellationToken token)
    {
        var resultOrdersList = await _mediator.Send(new GetOrdersQuery(), token);

        if (resultOrdersList.IsFailure)
            return StatusCode(ErrorMapper.GetStatusCode(resultOrdersList.Error), resultOrdersList.Error);
        
        return Ok(resultOrdersList.Value);
    }
}