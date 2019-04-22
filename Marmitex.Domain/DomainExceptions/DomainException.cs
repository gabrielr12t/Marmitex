using System;

namespace Marmitex.Domain.DomainExceptions
{
    public class DomainException : Exception
    {
        public DomainException(string error) : base(error) { }
        public static void When(bool HasError, string error)
        {
            if (HasError) throw new DomainException(error);
        }
    }
}