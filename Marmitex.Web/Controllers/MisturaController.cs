using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(MisturaViewModel misturaViewModel)
        {
            try
            {
                var mistura = _mapper.Map<Mistura>(misturaViewModel);
                _misturaRepository.Add(mistura);

                misturaViewModel = new MisturaViewModel();
                misturaViewModel.Misturas = _mapper.Map<IQueryable<MisturaViewModel>>(_misturaRepository.GetAll()); // pegando todas misturas e convertendo para viewmodel

                ModelState.Clear();
                return View(misturaViewModel);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }
        }
    }
}