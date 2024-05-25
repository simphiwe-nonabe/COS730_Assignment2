using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LotusOrganiser.Entities;

namespace LotusOrganiser_API.Models.Person
{
    public class TeamMemberViewModel
    {
        private TeamMemberViewModel()
        {
            TeamMemberId = default!;
            Team = default!;
            Person = default!;
        }

        [JsonConstructor]
        public TeamMemberViewModel(long teamMemberId, string team, string person)
        {
            TeamMemberId = teamMemberId;
            Team = team;
            Person = person;
        }

        public long TeamMemberId { get; set; }
        public string Team { get; set; }
        public string Person { get; set; }
    }
}