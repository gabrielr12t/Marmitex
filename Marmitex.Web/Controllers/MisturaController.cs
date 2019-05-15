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
    public class MisturaController : Controller
    {
        private readonly IMisturaRepository _misturaRepository;
        private readonly IMapper _mapper;
        public MisturaController(IMisturaRepository misturaRepository, IMapper mapper)
        {
            _misturaRepository = misturaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Registro(int id)
        {
            try
            {
                var viewModel = new MisturaViewModel();
                var mistura = await _misturaRepository.GetById(id);
                if (mistura != null) viewModel = _mapper.Map<MisturaViewModel>(mistura);
                viewModel.Misturas = _mapper.Map<List<MisturaViewModel>>(await _misturaRepository.Ativos<Mistura>());//list de misturas para viewModel
                return View(viewModel);
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(new MisturaViewModel { Misturas = _mapper.Map<List<MisturaViewModel>>(await _misturaRepository.Ativos<Mistura>()) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Registro(MisturaViewModel misturaViewModel)
        {

            try
            {
                await _misturaRepository.Add(_mapper.Map<Mistura>(misturaViewModel));
                await _misturaRepository.Save();
                var MisturaMapper = _mapper.Map<List<MisturaViewModel>>(await _misturaRepository.Ativos<Mistura>());//list de misturas para viewModel
                misturaViewModel = new MisturaViewModel { Misturas = _mapper.Map<List<MisturaViewModel>>(await _misturaRepository.Ativos<Mistura>()) };

                ModelState.Clear();
                return View(misturaViewModel);
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(new MisturaViewModel { Misturas = _mapper.Map<List<MisturaViewModel>>(await _misturaRepository.Ativos<Mistura>()) });
            }
        }

        public async Task<IActionResult> Desativar(int Id)
        {
            ModelState.Clear();
            var mistura = await _misturaRepository.GetById(Id);
            if (mistura != null) await _misturaRepository.Desativar<Mistura>(mistura);
            await _misturaRepository.Save();
            return RedirectToAction(nameof(Registro));
        }
    }
}