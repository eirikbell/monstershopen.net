using System.Data.Entity.ModelConfiguration;
using DomainModel;

namespace DataLayer.EntityMapping
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            ToTable("Order");

            HasKey(o => o.OrderId);

            Property(o => o.OrderId).HasColumnName("OrderGuid").IsRequired();
            Property(o => o.Date).HasColumnName("OrderDate").IsRequired();
            Property(o => o.Sum).HasColumnName("Sum").IsRequired();
        }
    }
}