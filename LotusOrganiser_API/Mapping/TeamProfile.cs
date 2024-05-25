using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.Team;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamViewModel>();

            CreateMap<TeamCreationModel, Team>();
        }
    }
}