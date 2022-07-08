using ApiDotNet.Domain.Entities;

namespace ApiDotNet.Domain.Repositories
{
    public interface IPersonRepository
    {
         Task<Person> GetByIdAsync(int id);
         Task<ICollection<Person>> GetPeopleAsync();
         Task<Person> CreateAsync(Person person);
         Task EditAsync(Person person);
         Task DeleteAsync(Person person);
         Task<int> GetIDByDocumentAsync(string document);
    }
}