using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LotusOrganiser.Data;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;

namespace LotusOrganiser_Repository.Repositories
{
    public sealed class TeamRepository : ITeamRepository
    {
        private readonly LotusOrganiserDbContext _context;
        private readonly ILogger<TeamRepository> _logger;

        public TeamRepository(LotusOrganiserDbContext context, ILogger<TeamRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
            try
            {
                await _context.Teams.AddAsync(team);
                await _context.SaveChangesAsync();
                return team;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to add Team - {name}", team.Name);
                throw;
            }
        }

        public async Task<Team?> GetTeamByIdAsync(long teamId)
        {
            return await _context.Teams.FindAsync(teamId);
        }

        public async Task<Team?> UpdateTeamAsync(long id, Team updatedTeam)
        {
            try
            {
                Team? team = await _context.Teams.FindAsync(id);

                if (team == null)
                {
                    return null;
                }

                team.Name = updatedTeam.Name;
                await _context.SaveChangesAsync();
                return team;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to update team with id - {id}", updatedTeam.TeamId);
                throw;
            }
        }

        public async Task<Team?> DeleteTeamAsync(long id)
        {
            try
            {
                Team? team = await _context.Teams.FindAsync(id);

                if (team == null)
                {
                    return null;
                }

                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
                return team;
            }
            catch (Exception exception) 
            {
                _logger.LogError(exception, "Unable to delete team with id - {id}", id);
                throw;
            }
        }
    }
}
