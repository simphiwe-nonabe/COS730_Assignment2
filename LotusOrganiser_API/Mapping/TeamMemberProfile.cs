using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.TeamMember;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class TeamMemberProfile : Profile
    {
        public TeamMemberProfile()
        {
            CreateMap<TeamMember, TeamMemberViewModel>();

            CreateMap<TeamMemberCreationModel, TeamMember>();

            CreateMap<TeamMemberUpdateModel, TeamMember>();
        }
    }
}