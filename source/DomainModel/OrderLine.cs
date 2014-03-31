using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("OrderLine")]
    public class OrderLine
    {
        [Column("OrderLineId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderLineId { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        [Column("Price")]
        public double Price { get; set; }

        [NotMapped]
        public string Name
        {
            get { return Monster != null ? Monster.Name : null; }
        }

        [NotMapped]
        public double Sum
        {
            get { return Quantity*Price; }
        }

        [Column("MonsterId")]
        public int MonsterId { get; set; }
        [ForeignKey("MonsterId")]
        public virtual Monster Monster { get; set; }

        [Column("OrderId")]
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}