using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Person
{
    public class TeamMemberCreationModel
    {
        private TeamMemberCreationModel()
        {
            Name = default!;
            Code = default!;
            PersonId = default!;
        }

        [JsonConstructor]
        public TeamMemberCreationModel(string name, string code, long certificationTypeId)
        {
            Name = name;
            Code = code;
            PersonId = certificationTypeId;
        }

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