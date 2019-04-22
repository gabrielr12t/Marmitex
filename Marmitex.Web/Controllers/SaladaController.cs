using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Marmitex.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marmitex.Web.Controllers
{
    public class SaladaController : Controller
    {
        private readonly ICardapioRepository<Salada> _cardapioRepository;
        private readonly IMapper _mapper;

        public SaladaController(ISaladaRepository saladaRepository, ICardapioRepository<Salada> cardapioRepository, IMapper mapper)
        {
            _cardapioRepository = cardapioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Registro(int id)
        {
            try
            {
                await _cardapioRepository.RemoveProdutoAntigo<Salada>();
                var saladaViewModel = new SaladaViewModel();
                var salada = _cardapioRepository.GetById(id);
                if (salada != null) saladaViewModel = _mapper.Map<SaladaViewModel>(salada);
                saladaViewModel.Saladas = _mapper.Map<List<SaladaViewModel>>(_cardapioRepository.Ativos<Salada>());
                return View(saladaViewModel);
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty,e.Message);
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Registro(SaladaViewModel saladaViewModel)
        {
            try
            {
                _cardapioRepository.AddCardapio(_mapper.Map<Salada>(saladaViewModel));
                //_cardapioRepository.AddCardapio<Salada>(_mapper.Map<Salada>(saladaViewModel));
                await _cardapioRepository.Save();

                var SaladaMapper = _mapper.Map<List<SaladaViewModel>>(_cardapioRepository.Ativos<Salada>());
                saladaViewModel = new SaladaViewModel { Saladas = SaladaMapper };
                ModelState.Clear();
                return View(saladaViewModel);
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }
        }

        public IActionResult Delete(int Id)
        {
            ModelState.Clear();
            var salada = _cardapioRepository.GetById(Id);
            if (salada != null) _cardapioRepository.Desativar<Salada>(salada);
            return RedirectToAction(nameof(Registro));
        }
    }
}