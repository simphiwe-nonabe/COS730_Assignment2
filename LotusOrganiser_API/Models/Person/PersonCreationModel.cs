using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Person
{
    public class PersonCreationModel
    {
        private PersonCreationModel()
        {
            Name = default!;
        }

        [JsonConstructor]
        public PersonCreationModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}