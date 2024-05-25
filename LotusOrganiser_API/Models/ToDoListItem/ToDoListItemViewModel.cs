using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.ToDoListItem
{
    public class ToDoListItemViewModel
    {
        private ToDoListItemViewModel()
        {
            Name = default!;
            Completed = false;
            TeamName = default!;
        }

        [JsonConstructor]
        public ToDoListItemViewModel(string name, bool completed, string teamName)
        {
            Name = name;
            Completed = completed;
            TeamName = teamName!;
        }

        public string Name { get; set; }

        public bool Completed { get; set; }

        public string TeamName { get; set; }
    }
}
