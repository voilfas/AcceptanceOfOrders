using OrderService.Domain.Entities;

namespace OrderService.Application.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken cancellationToken);
    
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<List<Order>> GetAllAsync(CancellationToken cancellationToken);
    
    Task SaveAsync(CancellationToken cancellationToken);
}