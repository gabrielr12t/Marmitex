using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces;
using Marmitex.Domain.Services.ClasseParaJson;
using Marmitex.Domain.Services.Cookie;
using Marmitex.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Marmitex.Web.Controllers
{
    public class MarmitaController : Controller
    {
        private readonly ICookieService _cookieService;
        private readonly IJsonService _jsonService;
        private readonly IAcompanhamentoRepository _acompanhamentoRepository;
        private readonly ISaladaRepository _saladaRepository;
        private readonly IMapper _mapper;
        private readonly IMisturaRepository _misturaRepository;

        public MarmitaController(ICookieService cookieService, IJsonService jsonService, IMisturaRepository misturaRepository,
        ISaladaRepository saladaRepository, IAcompanhamentoRepository acompanhamentoRepository, IMapper mapper)
        {
            _cookieService = cookieService;
            _jsonService = jsonService;
            _acompanhamentoRepository = acompanhamentoRepository;
            _saladaRepository = saladaRepository;
            _mapper = mapper;
            _misturaRepository = misturaRepository;
        }

        //método para preencher classe
        private async Task<MarmitaViewModel> MarmitaViewModelDB()
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
        public async Task<IActionResult> Registro(ClienteViewModel clienteViewModel = null)
        {
            try
            {
                if (clienteViewModel == null) throw new Exception("Nenhum cliente selecionado");
                return View(await MarmitaViewModelDB());
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return RedirectToAction("Index", "Cliente");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Registro()
        {
            try
            {
                if (_cookieService.GetCookie("carrinho") == null) throw new Exception("Carrinho está vazio");
                if (_cookieService.GetCookie("cliente") == null) throw new Exception("Nenhum cliente selecionado");

                var carrinho = _jsonService.AnyJsonToClass<Marmita>(_cookieService.GetCookie("carrinho"));
                //var carrinho = JsonConvert.DeserializeObject<List<Marmita>>(GetCookie("carrinho"));
                var cliente = _jsonService.OneJsonToClass<Cliente>(_cookieService.GetCookie("cliente"));

                _cookieService.RemoveRange(new List<string> { "carrinho", "cliente" });//limpando cookie após a compra
                ModelState.Clear();
                return Ok(await MarmitaViewModelDB());
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(await MarmitaViewModelDB());
            }
        }
    }
}