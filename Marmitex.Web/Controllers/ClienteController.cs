using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Marmitex.Domain.Services.ClasseParaJson;
using Marmitex.Domain.Services.Cookie;
using Marmitex.Domain.Services.Email;
using Marmitex.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marmitex.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IJsonService _jsonService;
        private readonly ICookieService _cookieService;
        private readonly ISaladaRepository _saladaRepository;
        private readonly IMisturaRepository _misturaRepository;
        private readonly IAcompanhamentoRepository _acompanhamentoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public ClienteController(IEmailSender emailSender, IJsonService jsonService, ICookieService cookieService, IHostingEnvironment env, IClienteRepository clienteRepository, ISaladaRepository saladaRepository, IMisturaRepository misturaRepository,
        IAcompanhamentoRepository acompanhamentoRepository, IMapper mapper)
        {
            _jsonService = jsonService;
            _cookieService = cookieService;
            _saladaRepository = saladaRepository;
            _emailSender = emailSender;
            _misturaRepository = misturaRepository;
            _acompanhamentoRepository = acompanhamentoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        // -----


        public async Task<MarmitaViewModel> MarmitaViewModelDB()
        {
            //método para fazer select das Misturas, Acompanhamentos e Saladas e colocando numa lista em um objeto marmita
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
                if (_cookieService.GetCookie("cliente") != null) return RedirectToAction("Registro", "Marmita"); //se ja tem cliente no cookie, direciona para compra
                _cookieService.Remove("carrinho");// limpando cookie carrinho
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
                if (string.IsNullOrEmpty(viewModel.Numero)) throw new Exception("Campo número é obrigatório");//verificando se número de telefone foi inserido
                var cliente = await _clienteRepository.GetClienteByTelefone(viewModel.Numero);//select cliente by telefone               
                if (!string.IsNullOrEmpty(cliente.Nome)) // verificando se encontrou cliente 
                {
                    _cookieService.SetCookie("cliente", _jsonService.OneClasseToJson(cliente), 20);//adicionando cookie do cliente com o objeto cliente                    
                    return RedirectToAction("Registro", "Marmita");
                }
                return RedirectToAction(nameof(Cadastro), new { numero = viewModel.Numero });
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
                //verificando se objeto possui id para buscar, senão verifica se ele preencheu o campo número e busca pelo número , senão cria objeto vazio
                var cliente = id > 0 ? await _clienteRepository.GetById(id) : ((!string.IsNullOrEmpty(numero)) ? await _clienteRepository.GetClienteByTelefone(numero) : new Cliente());
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
        public async Task<IActionResult> Cadastro([FromQuery(Name = "ReturnURL")] string page, ClienteViewModel clienteViewModel)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteViewModel);//converter objeto clienteViewModel para cliente
                await _clienteRepository.Add(cliente);//adicionando cliente
                await _clienteRepository.Save();
                var id = cliente.Id;
                _cookieService.SetCookie("cliente", _jsonService.OneClasseToJson<Cliente>(await _clienteRepository.GetOneWithPredicate(x => x.Telefone.Equals(cliente.Telefone))), 20);//adicionando cookie cliente
                // if (!string.IsNullOrEmpty(page))// verificando se cliente está comprando e decide editar os dados 
                //     return RedirectToAction("Registro", "Marmita");//depois de salvar os dados, redirecionar de volta para marmita
                return RedirectToAction("Registro", "Marmita");
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
            var clientes = await _clienteRepository.GetAll();//pegando todos clientes
            var mappedCliente = _mapper.Map<List<ClienteViewModel>>(clientes); //objecto cliente para clienteviewmodel
            return mappedCliente.Any() ? View(mappedCliente) : View(new List<ClienteViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var cliente = await _clienteRepository.GetById(Id);//pegando cliente
                if (cliente != null) _clienteRepository.Remove(cliente);//removendo cliente
                return Ok(cliente);  //retornando
            }
            catch (System.Exception e)
            {
                return null;//validação feita no ajax
            }
        }
    }
}