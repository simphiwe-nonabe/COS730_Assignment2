using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Team
{
    public class TeamViewModel
    {
        private TeamViewModel()
        {
            Name = default!;
        }

        [JsonConstructor]
        public TeamViewModel(string name)
        {
            Name = name;
        } 

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
