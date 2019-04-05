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
    public class SaladaController : Controller
    {
        private readonly ICardapioRepository<Salada> _cardapioRepository;


        private readonly IMapper _mapper;

        public SaladaController(ISaladaRepository saladaRepository, ICardapioRepository<Salada> cardapioRepository, IMapper mapper)
        {
            _cardapioRepository = cardapioRepository;
            _mapper = mapper;
            _cardapioRepository.RemoveProdutoAntigo<Salada>();
        }

        [HttpGet]
        public IActionResult Registro(int id)
        {
            var saladaViewModel = new SaladaViewModel();
            var salada = _cardapioRepository.GetById(id);
            if (salada != null) saladaViewModel = _mapper.Map<SaladaViewModel>(salada);
            saladaViewModel.Saladas = _mapper.Map<List<SaladaViewModel>>(_cardapioRepository.GetAll());
            return View(saladaViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Registro(SaladaViewModel saladaViewModel)
        {
            try
            {
                _cardapioRepository.AddCardapio(_mapper.Map<Salada>(saladaViewModel));
                //_cardapioRepository.AddCardapio<Salada>(_mapper.Map<Salada>(saladaViewModel));
                await _cardapioRepository.Save();

                var SaladaMapper = _mapper.Map<List<SaladaViewModel>>(_cardapioRepository.GetAll());
                saladaViewModel = new SaladaViewModel { Saladas = SaladaMapper };
                ModelState.Clear();
                return View(saladaViewModel);
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
            var salada = _cardapioRepository.GetById(Id);
            if (salada != null) _cardapioRepository.Remove(salada);
            return RedirectToAction(nameof(Registro));
        }
    }
}