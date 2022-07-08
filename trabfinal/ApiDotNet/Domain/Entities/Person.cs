using System;
using Domain.obj;

namespace ApiDotNet.Domain.Entities
{
    public sealed class Person
    {
        public int Id {get; private set;}
        public string Name {get; private set;}
        public string Document {get; private set;}
        public string Phone {get; private set;}
        public ICollection<Purchase> Purchases {get; set;}

        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);
            Purchases = new List<Purchase>();
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidation.When(id < 0 , "id tem que sermaior que zero");
            Id = id;
            Validation(name, document, phone);
            Purchases = new List<Purchase>();

        }

        private void Validation(string document, string name, string phone)
        {
            DomainValidation.When(string.IsNullOrEmpty(name),"nome deve ser informado");
            DomainValidation.When(string.IsNullOrEmpty(document),"doc deve ser informado");
            DomainValidation.When(string.IsNullOrEmpty(phone),"fone deve ser informado");

            Name = name;
            Document = document;
            Phone = phone;

        }
    }
}
