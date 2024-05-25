using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LotusOrganiser.Entities;
using LotusOrganiser.Data;
using LotusOrganiser_Repository.Interfaces;


namespace LotusOrganiser_Repository.Repositories
{
    public sealed class PersonRepository : IPersonRepository
    {
        private readonly LotusOrganiserDbContext _context;

        private readonly ILogger<PersonRepository> _logger;

        public PersonRepository(LotusOrganiserDbContext context, ILogger<PersonRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Person> AddPersonAsync(Person person)
        {
            try
            {
                await _context.Persons.AddAsync(person);
                await _context.SaveChangesAsync();
                return person;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to add person - {name}", person.Name);
                throw;
            }
        }

        public async Task<Person?> DeletePersonAsync(long id)
        {
            try
            {
                Person? person = await _context.Persons.FindAsync(id);

                if (person == null)
                {
                    return null;
                }

                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
                return person;
            }
            catch (Exception exception) 
            {
                _logger.LogError(exception, "Unable to delete person with id - {id}", id);
                throw;
            }

        }

        public async Task<IEnumerable<Person>> FindPersonsByNameAsync(string name)
        {
            return await _context.Persons.Where(person => person.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person?> GetPersonByIdAsync(long id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<Person?> UpdatePersonAsync(long id, Person updatedPerson)
        {
            try
            {
                Person? person = await _context.Persons.FindAsync(id);

                if (person == null)
                {
                    return null;
                }

                person.Name = updatedPerson.Name;
                await _context.SaveChangesAsync();
                return person;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unable to update person with id - {id}", updatedPerson.PersonId);
                throw;
            }

        }
    }
}
