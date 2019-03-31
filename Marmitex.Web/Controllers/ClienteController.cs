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
                ViewBag.Message = "Preencha o campo";
                return View();
            }
            var cliente = _clienteRepository.GetClienteByTelefone(telefone);
            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);
            return string.IsNullOrEmpty(cliente.Nome) ? RedirectToAction(nameof(Registro), clienteViewModel) : RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public IActionResult Cadastro(int id, ClienteViewModel clienteViewModel)
        {
            var cliente = _clienteRepository.GetById(id);
            return cliente == null ? View(clienteViewModel) : View(_mapper.Map<ClienteViewModel>(cliente));
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro:{e.Message} ");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Registro(ClienteViewModel viewModel)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(viewModel);
                _clienteRepository.Add(cliente);

                ModelState.Clear();
                return RedirectToAction(nameof(Listar));
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro em {ex.Message}");
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
            if (cliente != null)
            {
                _clienteRepository.Remove(cliente);
            }
            return cliente != null ? Ok(cliente) : null;

        }
    }
}