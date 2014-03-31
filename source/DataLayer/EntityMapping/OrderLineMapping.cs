using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DomainModel;

namespace DataLayer.EntityMapping
{
    public class OrderLineMapping : EntityTypeConfiguration<OrderLine>
    {
        public OrderLineMapping()
        {
            ToTable("OrderLine");

            HasKey(ol => ol.OrderLineId);

            Property(ol => ol.OrderLineId)
                .HasColumnName("OrderLineId")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(ol => ol.Quantity).HasColumnName("Quantity").IsRequired();
            Property(ol => ol.Price).HasColumnName("Price").IsRequired();
            Property(ol => ol.MonsterId).HasColumnName("MonsterId").IsRequired();
            Property(ol => ol.OrderId).HasColumnName("OrderId").IsRequired();

            HasRequired(ol => ol.Order).WithMany(o => o.OrderLines).HasForeignKey(ol => ol.OrderId);
            HasRequired(ol => ol.Monster).WithMany().HasForeignKey(ol => ol.MonsterId);

            Ignore(ol => ol.Name);
            Ignore(ol => ol.Sum);
        }
    }
}