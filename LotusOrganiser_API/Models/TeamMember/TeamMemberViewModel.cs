using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LotusOrganiser.Entities;

namespace LotusOrganiser_API.Models.TeamMember
{
    public class TeamMemberViewModel
    {
        private TeamMemberViewModel()
        {
            TeamMemberId = default!;
            TeamName = default!;
            PersonName = default!;
        }

        [JsonConstructor]
        public TeamMemberViewModel(long teamMemberId, string teamName, string personName)
        {
            TeamMemberId = teamMemberId;
            TeamName = teamName;
            PersonName = personName;
        }

        public long TeamMemberId { get; set; }
        public string TeamName { get; set; }
        public string PersonName { get; set; }
    }
}