using System;
using Domain.obj;

namespace ApiDotNet.Domain.Entities
{
    public sealed class Product
    {
        public int Id {get; private set;}
        public string Name {get; private set;}
        public string CodErp {get; private set;}
        public int Price {get; private set;}
        public ICollection<Purchase> Purchases {get; set;}

        public Product(string name, string codErp, int price)
        {
            Validation(name, codErp, price);
            Purchases = new List<Purchase>();
        }

        public Product(int id, string name, string codErp, int price)
        {
            DomainValidation.When(Id < 0 , "id tem que sermaior que zero");
            Id = id;
            Validation(name, codErp, price);
            Purchases = new List<Purchase>();

        }

        private void Validation(string name, string codErp, int price)
        {
            DomainValidation.When(string.IsNullOrEmpty(name),"nome deve ser informado");
            DomainValidation.When(string.IsNullOrEmpty(codErp),"cod deve ser informado");
            DomainValidation.When(price < 0,"preco deve ser informado");

            Name = name;
            CodErp = codErp;
            Price = price;

        }
    }
}
