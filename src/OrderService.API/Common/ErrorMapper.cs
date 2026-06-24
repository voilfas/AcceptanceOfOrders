using OrderService.Domain.Common;

namespace OrderService.API.Common;

public static class ErrorMapper
{
    public static int GetStatusCode(Error error)
    {
        var responce = error.Code switch
        {
            "Order.NotFoundById" => StatusCodes.Status404NotFound,

            "Order.InvalidCityName" =>
                StatusCodes.Status400BadRequest,

            "Order.InvalidAddressName" =>
                StatusCodes.Status400BadRequest,

            "Order.InvalidWeight" =>
                StatusCodes.Status400BadRequest,

            "Order.InvalidPickUpDate" =>
                StatusCodes.Status400BadRequest,

            _ => StatusCodes.Status500InternalServerError
        };
        
        return responce;
    }
}