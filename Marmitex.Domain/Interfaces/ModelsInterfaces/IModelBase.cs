using System;

namespace Marmitex.Domain.Interfaces.ModelsInterfaces
{
    public interface IModelBase<T>
    {
        Guid Id { get; set; }
        void Validation(T t);
        void SetProperties(T t);
    }
}