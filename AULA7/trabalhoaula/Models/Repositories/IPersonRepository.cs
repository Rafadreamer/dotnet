namespace trabalhoaula.Models.Repositories
{
    public interface IPersonRepository
    {
         Person GetById(int id);
         
         List<Person>GetAll();

         void Create(Person person);

         void Update(Person person);

         Person Delete(int id);
    }
}