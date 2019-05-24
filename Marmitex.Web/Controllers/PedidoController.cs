using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces;
using Marmitex.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace Marmitex.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
        }
 
        [HttpGet]
        public async Task<IActionResult> Pedidos()
        {
            var pedidos = _mapper.Map<List<PedidoViewModel>>(await _pedidoRepository.GetPedidos(null));
            return View(pedidos);
        }

        //melhorar muito esse lixo
        private async Task<List<PedidoViewModel>> GetPedidos(string Key = null, string Telefone = null)
        {
            List<PedidoViewModel> pedidos = null;

            var status = Enum.GetValues(typeof(Status)).Cast<Status>();
            var statu = status.Where(s => s.ToString().Equals(Key)).FirstOrDefault();

            if (!string.IsNullOrEmpty(Telefone))
            {
                pedidos = _mapper
                    .Map<List<PedidoViewModel>>(await _pedidoRepository
                    .GetPedidos(s => s.Status.Equals(statu) && (s.Cliente.Telefone.Equals(Telefone) || s.Cliente.Celular.Equals(Telefone))));
                return pedidos;
            }
            pedidos = _mapper.Map<List<PedidoViewModel>>(await _pedidoRepository.GetPedidos(s => s.Status.Equals(statu)));
            return pedidos;
        }


        public async Task<IActionResult> _Pedidos(string Key = null, string Telefone = null)
        {
            return PartialView(await GetPedidos(Key, Telefone));
        }
    }
}