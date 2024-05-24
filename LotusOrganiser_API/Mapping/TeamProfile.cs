using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamViewModel>();
        }
    }
}