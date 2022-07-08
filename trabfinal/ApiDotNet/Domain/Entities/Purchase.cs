using System;
using Domain.obj;

namespace ApiDotNet.Domain.Entities
{
    public sealed class Purchase
    {
        public int Id {get; private set;}
        public int ProductId {get; private set;}
        public int PersonId {get; private set;}
        public DateTime Date {get; private set;}

        public Person Person {get; set;}
        public Product Product {get; set;}

        public Purchase(int productId, int personId)
        {
            Validation(productId, personId);
        }

        public Purchase(int id, int productId, int personId)
        {
            DomainValidation.When(id < 0 , "id tem que sermaior que zero");
            Id = id;
            Validation(productId, personId);

        }

        private void Validation(int productId, int personId)
        {
            DomainValidation.When(productId <= 0, "prod id deve ser informado");
            DomainValidation.When(personId <= 0, "cliente id deve ser informado");
            
        
            PersonId = personId;
            ProductId = productId;
            Date = DateTime.Now;

        }
    }
}
