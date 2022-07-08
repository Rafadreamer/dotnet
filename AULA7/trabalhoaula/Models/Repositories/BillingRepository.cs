using Microsoft.EntityFrameworkCore;
using trabalhoaula.Models.Repositories;

namespace trabalhoaula
{

    public class BillingRepository : IBillingRepository
    {
        private DataContext context;

        public BillingRepository(DataContext context)
        {
            this.context = context;
        }
        public void Create(Billing billing)
        {
            if (billing.Person.Id > 0) billing.Person = context.People.SingleOrDefault(cid => cid.Id == billing.Person.Id);

            context.Add(billing);
            context.SaveChanges();
        }

        public Billing Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Billing> GetAll()
        {
            return context.Billings.Include(cid => cid.Person).ToList();
        }

        public Billing GetById(int id)
        {
            return context.Billings.SingleOrDefault(i => i.Id == id);
        }

        public void Update(Billing billing)
        {
            throw new NotImplementedException();
        }
    }
}