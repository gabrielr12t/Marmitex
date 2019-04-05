using System.Collections.Generic;
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

            CreateMap<Mistura, MisturaViewModel>().ReverseMap();

            CreateMap<Acompanhamento, AcompanhamentoViewModel>().ReverseMap();

            CreateMap<MisturaViewModel, Mistura>().ReverseMap();

            CreateMap<SaladaViewModel, Salada>().ReverseMap();

        }
    }
}