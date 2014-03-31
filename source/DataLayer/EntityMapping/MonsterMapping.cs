using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DomainModel;

namespace DataLayer.EntityMapping
{
    public class MonsterMapping : EntityTypeConfiguration<Monster>
    {
        public MonsterMapping()
        {
            ToTable("Monster");

            HasKey(m => m.MonsterId);

            Property(m => m.MonsterId)
                .HasColumnName("MonsterId")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Name).HasColumnName("MonsterName").IsRequired().HasMaxLength(50);
            Property(m => m.Price).HasColumnName("PurchasePrice").IsRequired();
        }
    }
}