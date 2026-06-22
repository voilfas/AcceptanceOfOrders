using OrderService.Domain.Common;

namespace OrderService.Application.Errors;

public static class ApplicationErrors
{
    public static readonly Error OrderNotFoundById = new Error("Order wasn't found by this ID.", "Order.NotFoundById");
}