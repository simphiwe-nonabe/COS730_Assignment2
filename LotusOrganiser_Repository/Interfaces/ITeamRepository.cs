using LotusOrganiser.Entities;

namespace LotusOrganiser_Repository.Interfaces
{
    public interface ITeamRepository
    {
        public Task<IEnumerable<Team>> GetAllTeamsAsync();

        public Task<Team> CreateTeamAsync(Team team);

        public Task<Team?> GetTeamByIdAsync(long teamId);
    }
}
