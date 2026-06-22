using OrderService.Domain.Common;

namespace OrderService.Domain.Errors;

public static class OrderErrors
{
    public static readonly Error InvalidCityName = new Error("City name should contain from 1 to 168 symbols.", "Order.InvalidCityName");
    public static readonly Error InvalidAddressName = new Error("Address name should contain from 4 to 100 symbols.", "Order.InvalidAddressName");
    public static readonly Error InvalidWeight = new Error("Weight must be greater than 0 and less than or equal to 1500 kg.", "Order.InvalidWeight");
    public static readonly Error InvalidPickUpDate = new Error("Pick up date can't be earlier than the current time.", "Order.InvalidPickUpDate");
}