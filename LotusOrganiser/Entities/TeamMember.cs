using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotusOrganiser.Entities
{
    public sealed class TeamMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TeamMemberId { get; set; }

        [Required]
        public long TeamId { get; set; }

        [Required]
        public long PersonId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }
    }
}
