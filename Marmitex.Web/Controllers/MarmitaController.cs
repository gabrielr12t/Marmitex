using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces;
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
        private readonly IAcompanhamentoRepository _acompanhamentoRepository;
        private readonly ISaladaRepository _saladaRepository;
        private readonly IMapper _mapper;
        private readonly IMisturaRepository _misturaRepository;
        private readonly IMarmitaRepository _marmitaRepository;

        public MarmitaController(IMarmitaRepository marmitaRepository, IMisturaRepository misturaRepository,
        ISaladaRepository saladaRepository, IAcompanhamentoRepository acompanhamentoRepository, IMapper mapper)
        {
            _acompanhamentoRepository = acompanhamentoRepository;
            _saladaRepository = saladaRepository;
            _mapper = mapper;
            _misturaRepository = misturaRepository;
            _marmitaRepository = marmitaRepository;
        }
        private string GetCookie(string cookie)
        {
            return Request.Cookies[cookie];
        }
        private void RemoveCookie(string keys)
        {
            Response.Cookies.Delete(keys);
        }
        private void RemoveCookies(List<string> keys)
        {
            foreach (var item in keys) Response.Cookies.Delete(item);
        }
        //método para preencher classe
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
        public IActionResult Registro(ClienteViewModel clienteViewModel = null)
        {
            //if (string.IsNullOrEmpty(clienteViewModel.Nome)) return RedirectToAction("Cadastro", "Cliente");
            return View(MarmitaViewModelDB());
        }
        [HttpPost]
        public IActionResult Registro()
        {
            try
            {
                if (GetCookie("carrinho") == null) throw new Exception("Carrinho está vazio");
                if (GetCookie("cliente") == null) throw new Exception("Nenhum cliente selecionado");
                var carrinho = JsonConvert.DeserializeObject<List<Marmita>>(GetCookie("carrinho"));
                var cliente = JsonConvert.DeserializeObject<Cliente>(GetCookie("cliente"));
                
                RemoveCookies(new List<string> { "cliente", "carrinho" });//limpando cookie após a compra
                ModelState.Clear();
                return Ok(MarmitaViewModelDB());
            }
            catch (Exception e)
            {
                // ModelState.AddModelError("", "Ocorreu um erro, tente novamente");
                ModelState.AddModelError("", e.Message);
                return View(MarmitaViewModelDB());
            }
        }
    }
}