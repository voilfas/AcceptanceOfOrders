using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.OrderNumber)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.SenderCity)
            .IsRequired()
            .HasMaxLength(168);
        
        builder.Property(x => x.SenderAddress)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.ReceiverCity)
            .IsRequired()
            .HasMaxLength(168);
        
        builder.Property(x => x.ReceiverAddress)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Weight)
            .IsRequired()
            .HasPrecision(10, 3);
        
        builder.Property(x => x.PickUpDate)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.HasIndex(x => x.OrderNumber)
            .IsUnique();
    }
}