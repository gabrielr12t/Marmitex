using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces;
using Marmitex.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

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

        //método para preencher classe
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
        public IActionResult Registro(ClienteViewModel clienteViewModel)
        {
            return View(MarmitaViewModelDB());
        }
        [HttpPost]
        public IActionResult Registro(int misturaId, int[] selectAcompanhamentos, int saladaId, Tamanho tamanho, string observacao, string entrega)
        {
            try
            {
                // arrumar esse código horroroso ********************************************
                var acompanhamentos = new List<Acompanhamento>();
                var mistura = _misturaRepository.GetById(misturaId);
                foreach (var item in selectAcompanhamentos)
                {
                    acompanhamentos.Add(_acompanhamentoRepository.GetById(item));
                }
                //******************************************************************** */

                Marmita marmita = new Marmita
                {
                    Mistura = new Mistura
                    {
                        Id = mistura.Id,
                        AcrescimoValor = mistura.AcrescimoValor,
                        Nome = mistura.Nome
                    },
                    Salada = new Salada
                    {
                        Id = saladaId
                    },
                    Tamanho = tamanho,
                    Observacao = observacao,
                    Acompanhamentos = acompanhamentos
                };
                _marmitaRepository.Add(marmita);
                return View(MarmitaViewModelDB());
            }
            catch (System.Exception e)
            {
                // ModelState.AddModelError("", "Ocorreu um erro, tente novamente");
                ModelState.AddModelError("","");
                return View(MarmitaViewModelDB());
            }

        }
    }
}