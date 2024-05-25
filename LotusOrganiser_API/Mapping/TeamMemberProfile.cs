using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.TeamMember;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class TeamMemberProfile : Profile
    {
        public TeamMemberProfile()
        {
            CreateMap<TeamMember, TeamMemberViewModel>()
                .ForMember(m => m.TeamName, opt => opt.MapFrom(e => e.Team.Name));

            CreateMap<TeamMemberCreationModel, TeamMember>()
                .ForMember(m => m.TeamId, opt => opt.MapFrom(e => e.TeamId));

            CreateMap<TeamMemberUpdateModel, TeamMember>();
        }
    }
}