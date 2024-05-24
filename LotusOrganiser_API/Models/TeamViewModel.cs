using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models
{
    public sealed class TeamViewModel
    {
        private TeamViewModel()
        {
            TeamId = default!;
            Name = default!;
        }

        [JsonConstructor]
        public TeamViewModel(long teamId, string name)
        {
            TeamId = teamId;
            Name = name;
        }

        [Required]
        public long TeamId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
