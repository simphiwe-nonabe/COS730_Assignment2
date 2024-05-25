using LotusOrganiser.Entities;

namespace LotusOrganiser_Repository.Interfaces
{
    public interface ITeamMemberRepository
    {
        public Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync();

        public Task<IEnumerable<TeamMember>> GetTeamMembersByTeamIdAsync(long id);

        public Task<IEnumerable<TeamMember>> FindTeamsMemberBelongsToByNameAsync(string name);

        public Task<TeamMember> AddTeamMemberAsync(TeamMember teamMember);

        public Task<TeamMember?> UpdateTeamMemberAsync(long id, TeamMember updatedTeamMember);

        public Task<TeamMember?> DeleteTeamMemberAsync(long id);

        public Task<IEnumerable<TeamMember>> FindTeamMembersByTeamNameAsync(string name);

    }
}
