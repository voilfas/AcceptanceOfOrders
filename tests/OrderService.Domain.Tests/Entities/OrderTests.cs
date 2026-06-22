using FluentAssertions;
using OrderService.Domain.Entities;
using OrderService.Domain.Errors;

namespace OrderService.Domain.Tests.Entities;

public class OrderTests
{
    [Fact]
    public void Create_ShouldCreateOrder_WhenDataIsValid()
    {
        var pickupDate = DateTime.UtcNow.AddDays(1);
        
        var result = Order.Create(
            "Санкт-Петербург",
            "Голикова 1",
            "Москва",
            "Захарова 2",
            120.500m,
            pickupDate);
        
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();

        result.Value!.SenderCity.Should().Be("Санкт-Петербург");
        result.Value.ReceiverCity.Should().Be("Москва");
        result.Value.Weight.Should().Be(120.500m);
        result.Value.OrderNumber.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenSenderCityIsEmpty()
    {
        var result = Order.Create(
            "",
            "Голикова 1",
            "Москва",
            "Захарова 2",
            20,
            DateTime.UtcNow.AddDays(1));
        
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(OrderErrors.InvalidCityName);
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenReceiverCityIsEmpty()
    {
        var result = Order.Create(
            "Санкт-Петербург",
            "Голикова 1",
            "",
            "Захарова 2",
            20,
            DateTime.UtcNow.AddDays(1));
        
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(OrderErrors.InvalidCityName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("AA")]
    [InlineData("AAA")]
    public void Create_ShouldReturnFailure_WhenSenderAddressIsInvalid(string address)
    {
        var result = Order.Create(
            "Санкт-Петербург",
            address,
            "Москва",
            "Захарова 2",
            10,
            DateTime.UtcNow.AddDays(1));
        
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(OrderErrors.InvalidAddressName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    [InlineData(-100)]
    public void Create_ShouldReturnFailure_WhenWeightIsLessThanOrEqualToZero(decimal weight)
    {
        var result = Order.Create(
            "Санкт-Петербург",
            "Голикова 1",
            "Москва",
            "Захарова 2",
            weight,
            DateTime.UtcNow.AddDays(1));
        
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(OrderErrors.InvalidWeight);
    }

    [Theory]
    [InlineData(1500.01)]
    [InlineData(2000)]
    [InlineData(10000)]
    public void Create_ShouldReturnFailure_WhenWeightExceedsMaximumLimit(decimal weight)
    {
        var result = Order.Create(
            "Санкт-Петербург",
            "Голикова 1",
            "Москва",
            "Захарова 2",
            weight,
            DateTime.UtcNow.AddDays(1));

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(OrderErrors.InvalidWeight);
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenPickupDateIsInThePast()
    {
        var result = Order.Create(
            "Санкт-Петербург",
            "Голикова 1",
            "Москва",
            "Захарова 2",
            10,
            DateTime.UtcNow.AddDays(-1));
        
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(OrderErrors.InvalidPickUpDate);
    }

    [Fact]
    public void Create_ShouldGenerateOrderNumber()
    {
        var result = Order.Create(
            "Санкт-Петербург",
            "Голикова 1",
            "Москва",
            "Захарова 2",
            10,
            DateTime.UtcNow.AddDays(1));
        
        result.IsSuccess.Should().BeTrue();
        result.Value!.OrderNumber.Should().StartWith("ORD-");
    }
}