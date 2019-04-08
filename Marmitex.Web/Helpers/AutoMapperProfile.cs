using System.Collections.Generic;
using System.Linq;
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

            // CreateMap<MarmitaViewModel, Marmita>().ReverseMap();

            CreateMap<Marmita, MarmitaViewModel>()
            .ForMember(vm => vm.MisturaId, conf => conf.MapFrom(m => m.Mistura.Id))
            .ForMember(vm => vm.SaladaId, conf => conf.MapFrom(m => m.Salada.Id))
            .ForMember(vm => vm.TamanhoId, conf => conf.MapFrom(m => m.Tamanho))
            .ForMember(vm => vm.Marmitas, conf => conf.MapFrom(m => m));


            // CreateMap<Marmita, MarmitaViewModel>()
            // .ForMember(vm => vm.Acompanhamentos, conf => conf.MapFrom(marm => marm.Acompanhamentos))
            // .ForMember(vm => vm.Saladas, conf => conf.MapFrom(marm => marm.Saladas))
            // .ForMember(vm => vm.Misturas, conf => conf.MapFrom(marm => marm.Misturas));
        }
    }
}