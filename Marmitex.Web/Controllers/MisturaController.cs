using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Marmitex.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            //get all misturas do dia
            var misturaViewModel = new MisturaViewModel();
            // -----------------------
            var mistura = _misturaRepository.GetById(id);

            if (mistura != null) misturaViewModel = _mapper.Map<MisturaViewModel>(mistura);

            //atribuindo misturas do dia a viewModel
            misturaViewModel.Misturas = _mapper.Map<List<MisturaViewModel>>(_misturaRepository.GetAll());//list de misturas para viewModel
            ModelState.Clear();
            return View(misturaViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Registro(MisturaViewModel misturaViewModel)
        {
            try
            {               
                _misturaRepository.Add(_mapper.Map<Mistura>(misturaViewModel));
                await _misturaRepository.Save();
                //Get all misturas do dia
                var MisturaMapper = _mapper.Map<List<MisturaViewModel>>(_misturaRepository.GetAll());//list de misturas para viewModel

                misturaViewModel = new MisturaViewModel();
                misturaViewModel.Misturas = MisturaMapper;
                // -----------------------------                
                ModelState.Clear();

                return View(misturaViewModel);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }
        }


        public IActionResult Delete(int Id)
        {
            ModelState.Clear();
            var mistura = _misturaRepository.GetById(Id);
            if (mistura != null) _misturaRepository.Remove(mistura);
            //await _misturaRepository.Save();
            return RedirectToAction(nameof(Registro));

        }
    }
}