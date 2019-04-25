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
        public IActionResult Registro(int id)
        {
            Mistura mistura = null;
            MisturaViewModel viewModel = null;
            try
            {
                viewModel = new MisturaViewModel();
                mistura = _misturaRepository.GetById(id);
                if (mistura != null) viewModel = _mapper.Map<MisturaViewModel>(mistura);
                viewModel.Misturas = _mapper.Map<List<MisturaViewModel>>(_misturaRepository.Ativos<Mistura>());//list de misturas para viewModel
                return View(viewModel);
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(viewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Registro(MisturaViewModel misturaViewModel)
        {

            try
            {
                _misturaRepository.Add(_mapper.Map<Mistura>(misturaViewModel));
                await _misturaRepository.Save();
                var MisturaMapper = _mapper.Map<List<MisturaViewModel>>(_misturaRepository.Ativos<Mistura>());//list de misturas para viewModel
                misturaViewModel = new MisturaViewModel { Misturas = MisturaMapper };
                ModelState.Clear();
                return View(misturaViewModel);
            }
            catch (System.Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(misturaViewModel);
            }
        }


        public IActionResult Desativar(int Id)
        {
            ModelState.Clear();
            var mistura = _misturaRepository.GetById(Id);
            if (mistura != null) _misturaRepository.Desativar<Mistura>(mistura);
            //await _misturaRepository.Save();
            return RedirectToAction(nameof(Registro));
        }
    }
}