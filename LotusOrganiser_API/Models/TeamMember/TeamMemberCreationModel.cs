using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.TeamMember
{
    public class TeamMemberCreationModel
    {
        private TeamMemberCreationModel()
        {
            TeamId = default!;
            PersonId = default!;
        }

        [JsonConstructor]
        public TeamMemberCreationModel(long teamId, long personId)
        {
            TeamId = teamId;
            PersonId = personId;
        }


        [Required]
        public long TeamId { get; set; }

        [Required]
        public long PersonId { get; set; }
    }
}