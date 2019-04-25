using System;

namespace Marmitex.Domain.DomainExceptions
{
    public class ExceptionClass : Exception
    {
        public ExceptionClass(string error) : base(error) { }
        public static void Exec(bool HasError, string error)
        {
            if (HasError) throw new ExceptionClass(error);
        }
    }
}