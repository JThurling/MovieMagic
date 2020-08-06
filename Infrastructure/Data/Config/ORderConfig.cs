using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfig : IEntityTypeConfiguration<OrderedItems>
    {
        public void Configure(EntityTypeBuilder<OrderedItems> builder)
        {
            builder.HasOne(p => p.Order)
                .WithMany(o => o.Movies)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
