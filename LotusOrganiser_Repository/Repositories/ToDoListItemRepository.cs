using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LotusOrganiser.Data;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;
using System;

namespace LotusOrganiser_Repository.Repositories
{
    public sealed class ToDoListItemRepository : IToDoListItemRepository
    {
        private readonly LotusOrganiserDbContext _context;

        private readonly ILogger<ToDoListItemRepository> _logger;

        private readonly ITeamRepository _teamRepository;

        public ToDoListItemRepository(LotusOrganiserDbContext context, ILogger<ToDoListItemRepository> logger, ITeamRepository teamRepository)
        {
            _context = context;
            _logger = logger;
            _teamRepository = teamRepository;
        }
        public async Task<IEnumerable<ToDoListItem>> GetAllToDoListItemsAsync()
        {
            return await _context.ToDoListItems
                .Include(item => item.Team)
                .ToListAsync();
        }

        public async Task<ToDoListItem> CreateToDoListItemAsync(ToDoListItem item)
        {
            try
            {
                Team? team = await
                    _teamRepository.GetTeamByIdAsync(item.TeamId);

                if (team == null)
                {
                    throw new Exception($"ToDo list item can not be created without assignee team. Please create team first");
                }

                item.Team = team;

                await _context.ToDoListItems.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to add ToDoListItem - {name}", item.Name);
                throw;
            }
        }

        public async Task<ToDoListItem?> GetToDoListItemByIdAsync(long itemId)
        {
            return await _context.ToDoListItems
                .Include(item => item.Team)
                .FirstOrDefaultAsync(item => item.ItemId == itemId) ?? null;
        }

        public async Task<ToDoListItem?> UpdateToDoListItemAsync(long id, ToDoListItem updatedItem)
        {
            try
            {
                ToDoListItem? item = await _context.ToDoListItems.FindAsync(id);

                if (item == null)
                {
                    return null;
                }

                Team? team = await
                    _teamRepository.GetTeamByIdAsync(updatedItem.TeamId);
                if (team == null)
                {
                    throw new Exception($"Team with id - {updatedItem.TeamId} does not exist. Please make assignee team");
                }

                item.Name = updatedItem.Name;
                item.Completed = updatedItem.Completed;
                item.Team = team;

                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to update item with id - {id}", updatedItem.ItemId);
                throw;
            }
        }

        public async Task<ToDoListItem?> DeleteToDoListItemAsync(long id)
        {
            try
            {
                ToDoListItem? item = await _context.ToDoListItems
                    .Include(item => item.Team).
                    FirstOrDefaultAsync(item => item.ItemId == id) ?? null;

                if (item == null)
                {
                    return null;
                }

                _context.ToDoListItems.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to delete item with id - {id}", id);
                throw;
            }
        }
    }
}
