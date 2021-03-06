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
            CreateMap<MarmitaAcompanhamento, MarmitaAcompanhamentoViewModel>().ReverseMap();

            CreateMap<MisturaViewModel, Mistura>().ReverseMap();

            CreateMap<SaladaViewModel, Salada>().ReverseMap();

            CreateMap<Marmita, MarmitaAcompanhamento>()
            .ForMember(ma => ma.Acompanhamento, conf => conf.MapFrom(m => m.Acompanhamentos))
            .ForMember(ma => ma.Marmita, conf => conf.MapFrom(m => m));

            CreateMap<Pedido, PedidoViewModel>().ReverseMap();//source -> destination

            CreateMap<Marmita, MarmitaViewModel>().ReverseMap();
            // .ForMember(vm => vm.MisturaId, conf => conf.MapFrom(m => m.Mistura.Id))
            // .ForMember(vm => vm.SaladaId, conf => conf.MapFrom(m => m.Salada.Id))
            // .ForMember(vm => vm.TamanhoId, conf => conf.MapFrom(m => m.Tamanho))
            // .ForMember(vm => vm.Marmitas, conf => conf.MapFrom(m => m));

        }
    }
}