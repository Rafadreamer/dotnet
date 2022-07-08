using Microsoft.EntityFrameworkCore;
using trabalhoaula.Models.Repositories;

namespace trabalhoaula
{

    public class PersonRepository : IPersonRepository
    {
        private DataContext context;

        public PersonRepository(DataContext context)
        {
            this.context = context;
        }
        public void Create(Person person)
        {
            if (person.City.Id > 0) person.City = context.Cities.SingleOrDefault(cid => cid.Id == person.City.Id);

            context.Add(person);
            context.SaveChanges();
        }

        public Person Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            return context.People.Include(cid => cid.City).ToList();
        }

        public Person GetById(int id)
        {
            return context.People.SingleOrDefault(i => i.Id == id);
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}