using Microsoft.AspNetCore.Mvc;
using trabalhoaula.Models.Repositories;

namespace trabalhoaula
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController :ControllerBase
    {
        private IPersonRepository repository;
        public PeopleController(IPersonRepository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet()]
        public IEnumerable<Person>Get()
        {
            return repository.GetAll();
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Person person)
        {
            repository.Create(person);
            return Ok(person);
        }
        
    }
}