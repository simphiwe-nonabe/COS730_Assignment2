using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Person
{
    public class PersonViewModel
    {
        private PersonViewModel()
        { 
            Name = default!;
        }

        [JsonConstructor]
        public PersonViewModel(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}