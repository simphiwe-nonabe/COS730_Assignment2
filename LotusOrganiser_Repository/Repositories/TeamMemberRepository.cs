using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LotusOrganiser.Data;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;

namespace LotusOrganiser_Repository.Repositories
{
    public sealed class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly LotusOrganiserDbContext _context;

        private readonly ILogger<TeamMemberRepository> _logger;

        private readonly IPersonRepository _personRepository;

        public TeamMemberRepository(LotusOrganiserDbContext context, ILogger<TeamMemberRepository> logger, IPersonRepository personRepository)
        {
            _context = context;
            _logger = logger;
            _personRepository = personRepository;
        }

        public async Task<TeamMember> AddTeamMemberAsync(TeamMember teamMember)
        {
            try
            {
                Person? person = await
                    _personRepository.GetPersonByIdAsync(teamMember.PersonId);
                if (person == null)
                {
                    throw new Exception($"TeamMember type with id - {teamMember.PersonId} does not exist.");
                }
                teamMember.Person = person;
                await _context.TeamMembers.AddAsync(teamMember);
                await _context.SaveChangesAsync();
                return teamMember;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to add TeamMember - {name}", teamMember.Person.Name);
                throw;
            }
        }

        public async Task<TeamMember?> DeleteTeamMemberAsync(long id)
        {
            try
            {
                TeamMember? teamMember = await _context.TeamMembers.FindAsync(id);

                if (teamMember == null)
                {
                    return null;
                }

                _context.TeamMembers.Remove(teamMember);
                await _context.SaveChangesAsync();
                return teamMember;

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to delete TeamMember with id - {id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<TeamMember>> FindTeamMembersByNameAsync(string name)
        {
            return await _context.TeamMembers
                .Include(person => person.Person)
                .Where(teamMember => teamMember.Person.Name.StartsWith(name)).ToListAsync();
        }

        public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync()
        {
            return await _context.TeamMembers
                .Include(person => person.Person)
                .ToListAsync();
        }

        public async Task<TeamMember?> GetTeamMemberByIdAsync(long id)
        {
            return await _context.TeamMembers
                .Include(teamMember => teamMember.Person)
                .FirstOrDefaultAsync(teamMember => teamMember.TeamMemberId == id) ?? null;
        }

        public async Task<IEnumerable<TeamMember>> FindTeamMembersByPersonAsync(string name)
        {
            return await _context.TeamMembers
                .Include(teamMember => teamMember.Person)
                .Where(teamMember => teamMember.Person.Name == name).ToListAsync();
        }

        public async Task<TeamMember?> UpdateTeamMemberAsync(TeamMember updatedTeamMember)
        {
            try
            {
                Person? person = await
                    _personRepository.GetPersonByIdAsync(updatedTeamMember.PersonId);
                if (person == null)
                {
                    throw new Exception($"TeamMember type with id - {updatedTeamMember.PersonId} does not exist.");
                }

                TeamMember? teamMember = await _context.TeamMembers.FindAsync(updatedTeamMember.TeamMemberId);

                if (teamMember == null)
                {
                    return null;
                }

                teamMember.Person.Name = updatedTeamMember.Person.Name;
                teamMember.Person = person;
                _context.Update(teamMember);
                await _context.SaveChangesAsync();
                return teamMember;

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to update TeamMember with id - {id}", updatedTeamMember.TeamMemberId);
                throw;
            }
        }

        Task<IEnumerable<TeamMember>> ITeamMemberRepository.FindTeamMembersByTeamMemberTypeAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
