using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Marmitex.Domain.Services.Email;
using Marmitex.Web.Services;
using Marmitex.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marmitex.Web.Controllers
{
    public class ClienteController : Controller
    {
        public const string MSG = @"Olá senhor Edson Romero, gostariamos de notificá-lo de muitos acessos a sua conta na qual identificamos possíveis hackers
            , por este motivo estaremos tentando enviar esta mensagem a você, obrigado pela colaboração !";
        private readonly ISaladaRepository _saladaRepository;
        private readonly IMisturaRepository _misturaRepository;
        private readonly IAcompanhamentoRepository _acompanhamentoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public ClienteController(IEmailSender emailSender, IHostingEnvironment env, IClienteRepository clienteRepository, ISaladaRepository saladaRepository, IMisturaRepository misturaRepository,
        IAcompanhamentoRepository acompanhamentoRepository, IMapper mapper)
        {
            _saladaRepository = saladaRepository;
            _emailSender = emailSender;
            _misturaRepository = misturaRepository;
            _acompanhamentoRepository = acompanhamentoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;

        }
        // -----
        public async Task EnviarEmail(string email, string assunto, string mensagem)
        {
            try
            {
                await _emailSender.SendEmailAsync(email, assunto, mensagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // ------

        public MarmitaViewModel MarmitaViewModelDB()
        {
            var marmitaViewModel = new MarmitaViewModel
            {
                Saladas = _mapper.Map<List<SaladaViewModel>>(_saladaRepository.Ativos<Salada>()),
                Misturas = _mapper.Map<List<MisturaViewModel>>(_misturaRepository.Ativos<Mistura>()),
                Acompanhamentos = _mapper.Map<List<AcompanhamentoViewModel>>(_acompanhamentoRepository.Ativos<Acompanhamento>())
            };
            return marmitaViewModel;
        }//---------------------

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return View(MarmitaViewModelDB());
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(MarmitaViewModelDB());
            }
            //EnviarEmail("edsonromero2014@gmail.com", "Steam Authorize", MSG).GetAwaiter();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(MarmitaViewModel viewModel)
        {
            try
            {

                if (string.IsNullOrEmpty(viewModel.Numero)) throw new ExceptionClass("Campo número é obrigatório");
                var cliente = _clienteRepository.GetClienteByTelefone(viewModel.Numero);
                return string.IsNullOrEmpty(cliente.Nome) ? RedirectToAction(nameof(Cadastro), new { numero = viewModel.Numero }) : RedirectToAction("Registro", "Marmita", _mapper.Map<ClienteViewModel>(cliente));
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(MarmitaViewModelDB());
            }
        }

        [HttpGet]
        public IActionResult Cadastro(int id, string numero = null)
        {
            try
            {
                var cliente = id > 0 ? _clienteRepository.GetById(id) : ((!string.IsNullOrEmpty(numero)) ? _clienteRepository.GetClienteByTelefone(numero) : new Cliente());
                return View(_mapper.Map<ClienteViewModel>(cliente));
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }

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
                //return RedirectToAction("Registro", "Marmita", clienteViewModel);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
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