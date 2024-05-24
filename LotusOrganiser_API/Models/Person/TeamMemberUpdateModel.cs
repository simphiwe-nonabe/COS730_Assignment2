using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Person
{
    public class TeamMemberUpdateModel
    {
        private TeamMemberUpdateModel()
        {
            TeamMemberId = default!;
            Name = default!;
            Code = default!;
            PersonId = default!;
        }

        [JsonConstructor]
        public TeamMemberUpdateModel(long teamMemberId, string name, string code, long personId)
        {
            TeamMemberId = teamMemberId;
            Name = name;
            Code = code;
            PersonId = personId;
        }

        [Required]
        public long TeamMemberId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        public long PersonId { get; set; }
    }
}