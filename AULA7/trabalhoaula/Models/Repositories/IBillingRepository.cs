namespace trabalhoaula.Models.Repositories
{
    public interface IBillingRepository
    {
         Billing GetById(int id);
         
         List<Billing>GetAll();

         void Create(Billing billing);

         void Update(Billing billing);

         Billing Delete(int id);
    }
}