using Microsoft.AspNetCore.Mvc;
using trabalhoaula.Models.Repositories;

namespace trabalhoaula
{
    [ApiController]
    [Route("[controller]")]
    public class BillingController :ControllerBase
    {
        private IBillingRepository repository;
        public BillingController(IBillingRepository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet("/test")]
        public IEnumerable<Billing>Get()
        {
            return repository.GetAll();
        }

        [HttpPost("/test")]
        public IActionResult Post([FromBody] Billing person)
        {
            repository.Create(person);
            return Ok(person);
        }
        
    }
}