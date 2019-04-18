using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Marmitex.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marmitex.Web.Controllers
{
    public class AcompanhamentoController : Controller
    {
        private readonly ICardapioRepository<Acompanhamento> _cardapioRepository;
        private readonly IMapper _mapper;

        public AcompanhamentoController(ICardapioRepository<Acompanhamento> cardapioRepository, IMapper mapper)
        {
            _cardapioRepository = cardapioRepository;
            _mapper = mapper;


        }

        [HttpGet]
        public IActionResult Registro(int id)
        {
            var acompanhamentoViewModel = new AcompanhamentoViewModel();
            var acompanhamento = _cardapioRepository.GetById(id);
            if (acompanhamento != null) acompanhamentoViewModel = _mapper.Map<AcompanhamentoViewModel>(acompanhamento);
            acompanhamentoViewModel.Acompanhamentos = _mapper.Map<List<AcompanhamentoViewModel>>(_cardapioRepository.Ativos<Acompanhamento>());
            return View(acompanhamentoViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Registro(AcompanhamentoViewModel acompanhamentoViewModel)
        {
            try
            {
                _cardapioRepository.Add(_mapper.Map<Acompanhamento>(acompanhamentoViewModel));
                await _cardapioRepository.Save();

                var AcompanhamentoMapper = _mapper.Map<List<AcompanhamentoViewModel>>(_cardapioRepository.Ativos<Acompanhamento>());
                acompanhamentoViewModel = new AcompanhamentoViewModel { Acompanhamentos = AcompanhamentoMapper };
                ModelState.Clear();
                return View(acompanhamentoViewModel);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Falha para salvar dados {e.Message}");
            }
        }

        public IActionResult Delete(int Id)
        {
            ModelState.Clear();
            var acompanhamento = _cardapioRepository.GetById(Id);
            if (acompanhamento != null) _cardapioRepository.Desativar<Acompanhamento>(acompanhamento);
            return RedirectToAction(nameof(Registro));
        }
    }
}