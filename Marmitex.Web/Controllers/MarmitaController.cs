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
        public string GetCookie(string cookie)
        {
            return Request.Cookies[cookie];
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


        private IActionResult Adicionar(Marmita marmita)
        {
            return View(MarmitaViewModelDB());
            // return RedirectToAction(nameof(Registro));
        }
        private IActionResult Finalizar()
        {
            var cookie = GetCookie("carrinho");
            var resultado = JsonConvert.DeserializeObject<List<ItensDoPedido>>(cookie);
            // return View(nameof(Registro));
            return View(MarmitaViewModelDB());
        }
        [HttpGet]
        public IActionResult Registro(ClienteViewModel clienteViewModel = null)
        {
            //if (string.IsNullOrEmpty(clienteViewModel.Nome)) return RedirectToAction("Cadastro", "Cliente");
            return View(MarmitaViewModelDB());
        }
        [HttpPost]
        public IActionResult Registro(int misturaId, int[] selectAcompanhamentos, int saladaId, Tamanho tamanho, string observacao, string entrega, string btn)
        {
            try
            {
                var acompanhamentos = _acompanhamentoRepository.GetByIds(selectAcompanhamentos);
                var mistura = _misturaRepository.GetById(misturaId);
                Marmita marmita = new Marmita(mistura, acompanhamentos, saladaId, tamanho, observacao, entrega);
                switch (btn)
                {
                    case "Adicionar":
                        return (Adicionar(marmita));
                    case "Finalizar":
                        return (Finalizar());
                }
                return View(MarmitaViewModelDB());
            }
            catch (System.Exception e)
            {
                // ModelState.AddModelError("", "Ocorreu um erro, tente novamente");
                ModelState.AddModelError("", e.Message);
                return View(MarmitaViewModelDB());
            }
        }
    }
}