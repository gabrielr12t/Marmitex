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

        private async Task<SaladaViewModel> GetSaladas()
        {
            var saladaViewModel = new SaladaViewModel
            {
                Saladas = _mapper.Map<List<SaladaViewModel>>(await _cardapioRepository.Ativos<Salada>())
            };
            return saladaViewModel;
        }

        [HttpGet]
        public async Task<IActionResult> Registro(int id)
        {
            try
            {
                var saladaViewModel = new SaladaViewModel();
                var salada = await _cardapioRepository.GetById(id);
                if (salada != null) saladaViewModel = _mapper.Map<SaladaViewModel>(salada);
                saladaViewModel.Saladas = _mapper.Map<List<SaladaViewModel>>(await _cardapioRepository.Ativos<Salada>());
                return View(saladaViewModel);
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(await GetSaladas());
            }

        }
        [HttpPost]
        public async Task<IActionResult> Registro(SaladaViewModel saladaViewModel)
        {
            try
            {
                await _cardapioRepository.AddCardapio(_mapper.Map<Salada>(saladaViewModel));
                await _cardapioRepository.Save();
                //_cardapioRepository.AddCardapio<Salada>(_mapper.Map<Salada>(saladaViewModel));

                ModelState.Clear();
                await _cardapioRepository.RemoveProdutoAntigo<Salada>();
                return View(await GetSaladas());
            }
            catch (System.Exception e)
            {               
                ModelState.AddModelError(string.Empty, e.Message);
                return View(await GetSaladas());
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            ModelState.Clear();
            var salada = await _cardapioRepository.GetById(Id);
            if (salada != null) await _cardapioRepository.Desativar<Salada>(salada);
            return RedirectToAction(nameof(Registro));
        }
    }
}