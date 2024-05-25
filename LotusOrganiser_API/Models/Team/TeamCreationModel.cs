using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Team
{
    public class TeamCreationModel
    {
        private TeamCreationModel()
        {
            Name = default!;
        }

        [JsonConstructor]
        public TeamCreationModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}