using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Monster")]
    public class Monster
    {
        [Column("MonsterId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MonsterId { get; set; }

        [Column("MonsterName")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Column("PurchasePrice")]
        public double Price { get; set; }
    }
}
