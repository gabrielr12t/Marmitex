using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        [HttpGet]
        public IActionResult Registro()
        {
            var marmitaViewModel = new MarmitaViewModel
            {                
                Saladas = _mapper.Map<List<SaladaViewModel>>(_saladaRepository.GetAll()),
                Misturas = _mapper.Map<List<MisturaViewModel>>(_misturaRepository.GetAll()),
                Acompanhamentos = _mapper.Map<List<AcompanhamentoViewModel>>(_acompanhamentoRepository.GetAll())
            };
            return View(marmitaViewModel);
        }
        [HttpPost]
        public IActionResult Registro(MarmitaViewModel viewModel)
        {
            return View();
        }
    }
}