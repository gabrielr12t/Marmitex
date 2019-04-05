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
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(string telefone)
        {
            if (string.IsNullOrEmpty(telefone))
            {
                ViewBag.Message = "Preencha o campo telefone";
                return View();
            }
            var cliente = _clienteRepository.GetClienteByTelefone(telefone);
            return string.IsNullOrEmpty(cliente.Nome) ? RedirectToAction(nameof(Cadastro), new { numero = telefone }) : RedirectToAction(nameof(Listar));
            //o else do return precisa retornar para o pedido
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