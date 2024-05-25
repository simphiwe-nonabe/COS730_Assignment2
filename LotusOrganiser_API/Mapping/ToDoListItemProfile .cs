using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.ToDoListItem;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class ToDoListItemProfile : Profile
    {
        public ToDoListItemProfile()
        {
            CreateMap<ToDoListItem, ToDoListItemViewModel>()
                .ForMember(m => m.TeamName, opt => opt.MapFrom(e => e.Team.Name));

            CreateMap<ToDoListItemCreationModel, ToDoListItem>()
                .ForMember(m => m.TeamId, opt => opt.MapFrom(e => e.TeamId));

        }
    }
}