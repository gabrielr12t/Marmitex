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
        #region dependencias
        private readonly ICookieService _cookieService;
        private readonly IJsonService _jsonService;
        private readonly IAcompanhamentoRepository _acompanhamentoRepository;
        private readonly ISaladaRepository _saladaRepository;
        private readonly IMapper _mapper;
        private readonly IMisturaRepository _misturaRepository;

        #endregion

        public MarmitaController(ICookieService cookieService, IJsonService jsonService, IMisturaRepository misturaRepository,
        ISaladaRepository saladaRepository, IAcompanhamentoRepository acompanhamentoRepository, IMapper mapper)
        {
            #region dependency injection

            _cookieService = cookieService;
            _jsonService = jsonService;
            _acompanhamentoRepository = acompanhamentoRepository;
            _saladaRepository = saladaRepository;
            _mapper = mapper;
            _misturaRepository = misturaRepository;

            #endregion
        }

        #region métodos adicionais
        private void VerifyCookies()
        {
            if (_cookieService.GetCookie("carrinho") == null) throw new Exception("Carrinho está vazio"); // verificando se tem item no carrinho
            if (_cookieService.GetCookie("cliente") == null) throw new Exception("Nenhum cliente selecionado"); // verificando se têm cliente no cookie["cliente"]
        }
        private async Task<MarmitaViewModel> MarmitaViewModelDB()
        {
            //método para fazer select das Misturas, Acompanhamentos e Saladas e colocando numa lista em um objeto marmita
            var marmitaViewModel = new MarmitaViewModel
            {
                Saladas = _mapper.Map<List<SaladaViewModel>>(await _saladaRepository.Ativos<Salada>()),
                Misturas = _mapper.Map<List<MisturaViewModel>>(await _misturaRepository.Ativos<Mistura>()),
                Acompanhamentos = _mapper.Map<List<AcompanhamentoViewModel>>(await _acompanhamentoRepository.Ativos<Acompanhamento>()),
                Cliente = _jsonService.OneJsonToClass<Cliente>(_cookieService.GetCookie("cliente")),
            };
            return marmitaViewModel;
        }
        #endregion


        [HttpGet]
        public async Task<IActionResult> Registro()
        {
            try
            {
                if (_cookieService.GetCookie("cliente") == null) throw new Exception("Nenhum cliente selecionado");// verificando se têm cliente no cookie["cliente"]
                return View(await MarmitaViewModelDB());
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return RedirectToAction("Index", "Cliente");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Registro(int id)
        {
            try
            {
                VerifyCookies();
                var carrinho = _jsonService.AnyJsonToClass<Marmita>(_cookieService.GetCookie("carrinho"));//convertendo array de json para lista de objeto Marmita
                var cliente = _jsonService.OneJsonToClass<Cliente>(_cookieService.GetCookie("cliente")); // convertendo json cliente para objeto cliente
                _cookieService.RemoveRange(new List<string> { "carrinho", "cliente" }); //limpando cookie da página após a compra
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