using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.ToDoListItem
{
    public class ToDoListItemCreationModel
    {
        private ToDoListItemCreationModel()
        {
            Name = default!;
            Completed = false;
            TeamId = default!;
        }

        [JsonConstructor]
        public ToDoListItemCreationModel(string name, bool completed , long teamId)
        {
            Name = name;
            Completed = completed;
            TeamId = teamId!;
        }

        public string Name { get; set; }

        public bool Completed { get; set; }

        public long TeamId { get; set; }
    }
}