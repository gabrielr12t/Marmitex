using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Marmitex.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marmitex.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ISaladaRepository _saladaRepository;
        private readonly IMisturaRepository _misturaRepository;
        private readonly IAcompanhamentoRepository _acompanhamentoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteController(IClienteRepository clienteRepository, ISaladaRepository saladaRepository, IMisturaRepository misturaRepository,
        IAcompanhamentoRepository acompanhamentoRepository, IMapper mapper)
        {
            _saladaRepository = saladaRepository;
            _misturaRepository = misturaRepository;
            _acompanhamentoRepository = acompanhamentoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public MarmitaViewModel MarmitaViewModelDB()
        {
            var marmitaViewModel = new MarmitaViewModel
            {
                Saladas = _mapper.Map<List<SaladaViewModel>>(_saladaRepository.GetAll()),
                Misturas = _mapper.Map<List<MisturaViewModel>>(_misturaRepository.GetAll()),
                Acompanhamentos = _mapper.Map<List<AcompanhamentoViewModel>>(_acompanhamentoRepository.GetAll())
            };
            return marmitaViewModel;
        }//---------------------

        [HttpGet]
        public IActionResult Index()
        {
            return View(MarmitaViewModelDB());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(MarmitaViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Numero))
            {                
                ViewBag.Message = "Preencha o campo viewModel.Numero";
                return View(MarmitaViewModelDB());
            }
            var cliente = _clienteRepository.GetClienteByTelefone(viewModel.Numero);
            return string.IsNullOrEmpty(cliente.Nome) ? RedirectToAction(nameof(Cadastro), new { numero = viewModel.Numero }) : RedirectToAction("Registro", "Marmita", _mapper.Map<ClienteViewModel>(cliente));
        }

        [HttpGet]
        public IActionResult Cadastro(int id, string numero = null)
        {
            var cliente = id > 0 ? _clienteRepository.GetById(id) : ((!string.IsNullOrEmpty(numero)) ? _clienteRepository.GetClienteByTelefone(numero) : new Cliente());
            return View(_mapper.Map<ClienteViewModel>(cliente));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(ClienteViewModel clienteViewModel)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteViewModel);
                _clienteRepository.Add(cliente);
                ModelState.Clear();
                return RedirectToAction(nameof(Listar));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message} ");
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var clientes = _clienteRepository.GetAll();
            var mappedCliente = _mapper.Map<List<ClienteViewModel>>(clientes);
            return mappedCliente.Any() ? View(mappedCliente) : View(new List<ClienteViewModel>());
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var cliente = _clienteRepository.GetById(Id);
            if (cliente != null) _clienteRepository.Remove(cliente);
            return cliente != null ? Ok(cliente) : null;
        }
    }
}