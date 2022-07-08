namespace Domain.obj
{
    public class DomainValidation : Exception
    {
        public DomainValidation(string error) : base(error)
        { }

        public static void When(bool hasError, string message)
        {
            if (hasError)
                throw new DomainValidation(message);
        }
    }
}