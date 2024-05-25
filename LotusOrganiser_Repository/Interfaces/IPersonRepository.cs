using LotusOrganiser.Entities;


namespace LotusOrganiser_Repository.Interfaces
{
    public interface IPersonRepository
    {
        public Task<Person> AddPersonAsync(Person person);

        public Task<IEnumerable<Person>> GetAllPersonsAsync();

        public Task<Person?> GetPersonByIdAsync(long id);

        public Task<IEnumerable<Person>> FindPersonsByNameAsync(string name);

        public Task<Person?> UpdatePersonAsync(long id, Person person);

        public Task<Person?> DeletePersonAsync(long id);

    }
}
