using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotusOrganiser.Entities
{
    public sealed class ToDoListItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ItemId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public bool Completed { get; set; }

        public long TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }

    }
}
