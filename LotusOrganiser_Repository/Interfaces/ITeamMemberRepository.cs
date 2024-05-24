using LotusOrganiser.Entities;

namespace LotusOrganiser_Repository.Interfaces
{
    public interface ITeamMemberRepository
    {
        public Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync();

        public Task<TeamMember?> GetTeamMemberByIdAsync(long id);

        public Task<IEnumerable<TeamMember>> FindTeamMembersByNameAsync(string name);

        public Task<TeamMember> AddTeamMemberAsync(TeamMember certification);

        public Task<TeamMember?> UpdateTeamMemberAsync(TeamMember updatedTeamMember);

        public Task<TeamMember?> DeleteTeamMemberAsync(long id);

        public Task<IEnumerable<TeamMember>>  FindTeamMembersByTeamMemberTypeAsync(string name);

    }
}
