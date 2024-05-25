using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotusOrganiser.Entities
{
    public sealed class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TeamId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
