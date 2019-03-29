using AutoMapper;
using Marmitex.Domain.Entidades;
using Marmitex.Web.ViewModels;

namespace Marmitex.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();                
        }
    }
}