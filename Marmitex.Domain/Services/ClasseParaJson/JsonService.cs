using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Marmitex.Domain.Services.ClasseParaJson
{
    public class JsonService : IJsonService
    {
        public string AnyClasseToJson<Tentity>(List<Tentity> objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }
        public List<Tentity> AnyJsonToClass<Tentity>(string classeString)
        {
            return JsonConvert.DeserializeObject<List<Tentity>>(classeString);
        }
        public string OneClasseToJson<Tentity>(Tentity objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }
        public Tentity OneJsonToClass<Tentity>(string classeString)
        {
            return JsonConvert.DeserializeObject<Tentity>(classeString);
        }
    }
}