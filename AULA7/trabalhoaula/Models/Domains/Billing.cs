namespace trabalhoaula
{
    public class Billing
    {
        public Billing() { }
        public Billing(int id, int valor, int data, Person person)
        {
            this.Id = id;
            this.Valor = valor;
            this.Data = data;
            this.Person = person;
        }

        public int Id { get; set; }
        public int Valor { get; set; }
        public int Data { get; set; }
        public Person Person { get; set; }
    }
}