using System.Collections.Generic;
using Marmitex.Domain.Interfaces;

namespace Marmitex.Domain.Services.ClasseParaJson
{
    public interface IJsonService
    {
        string OneClasseToJson<T>(T objeto);
        string AnyClasseToJson<T>(List<T> objeto);
        T OneJsonToClass<T>(string classeString);
        List<T> AnyJsonToClass<T>(string classeString);


    }
}