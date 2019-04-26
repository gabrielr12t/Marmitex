using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Marmitex.Domain.Services.Email;
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

        public async Task<MarmitaViewModel> MarmitaViewModelDB()
        {
            var marmitaViewModel = new MarmitaViewModel
            {
                Saladas = _mapper.Map<List<SaladaViewModel>>(await _saladaRepository.Ativos<Salada>()),
                Misturas = _mapper.Map<List<MisturaViewModel>>(await _misturaRepository.Ativos<Mistura>()),
                Acompanhamentos = _mapper.Map<List<AcompanhamentoViewModel>>(await _acompanhamentoRepository.Ativos<Acompanhamento>())
            };
            return marmitaViewModel;
        }//---------------------

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await MarmitaViewModelDB());
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(await MarmitaViewModelDB());
            }
            //EnviarEmail("edsonromero2014@gmail.com", "Steam Authorize", MSG).GetAwaiter();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(MarmitaViewModel viewModel)
        {
            try
            {
                if (string.IsNullOrEmpty(viewModel.Numero)) throw new Exception("Campo número é obrigatório");
                var cliente = await _clienteRepository.GetClienteByTelefone(viewModel.Numero);
                return string.IsNullOrEmpty(cliente.Nome) ? RedirectToAction(nameof(Cadastro), new { numero = viewModel.Numero }) : RedirectToAction("Registro", "Marmita", _mapper.Map<ClienteViewModel>(cliente));
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(await MarmitaViewModelDB());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cadastro(int id, string numero = null)
        {
            try
            {
                var cliente = id > 0 ? await _clienteRepository.GetById(id)  : ((!string.IsNullOrEmpty(numero)) ? await _clienteRepository.GetClienteByTelefone(numero) : new Cliente());
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
        public async Task<IActionResult> Cadastro(ClienteViewModel clienteViewModel)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteViewModel);
                await _clienteRepository.Add(cliente);
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
        public async Task<IActionResult> Listar()
        {
            var clientes = await _clienteRepository.GetAll();
            var mappedCliente = _mapper.Map<List<ClienteViewModel>>(clientes);
            return mappedCliente.Any() ? View(mappedCliente) : View(new List<ClienteViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var cliente = await _clienteRepository.GetById(Id);
            if (cliente != null) _clienteRepository.Remove(cliente);
            return cliente != null ? Ok(cliente) : null;
        }

    }
}