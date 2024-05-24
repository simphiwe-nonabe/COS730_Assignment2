using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Person
{
    public class TeamMemberViewModel
    {
        private TeamMemberViewModel()
        {
            TeamMemberId = default!;
            Name = default!;
            Code = default!;
            Person = default!;
        }

        [JsonConstructor]
        public TeamMemberViewModel(long certificationId, string name, string code, string certificationType)
        {
            TeamMemberId = certificationId;
            Name = name;
            Code = code;
            Person = certificationType;
        }

        public long TeamMemberId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Person { get; set; }
    }
}