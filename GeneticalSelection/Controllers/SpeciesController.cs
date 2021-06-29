using AutoMapper;
using GeneticalSelection.LoggerService;
using GeneticalSelection.Models.DataTransferObjects;
using GeneticalSelection.Models.Entities;
using GeneticalSelection.Models.Pages;
using GeneticalSelection.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Controllers
{
    public class SpeciesController : Controller
    {
        private IRepositoryManager repository;
        private ILoggerManager logger;
        private IMapper mapper;
        public SpeciesController(IRepositoryManager _repository,
            ILoggerManager _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }
        public IActionResult Index(QueryOptions options)
        {
            var species = repository.Species.GetAllSpecies(options);
            ViewBag.Genuses = repository.Genus.GetAllGenuses(new QueryOptions { });
            return View(species);
        }

        [HttpPost]
        public IActionResult CreateSpecies(Species species)
        {
            repository.Species.CreateSpecies(species.GenusId, species);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditSpecies(QueryOptions options, long speciesId)
        {
            ViewBag.SpeciesId = speciesId;
            ViewBag.Genuses = repository.Genus.GetAllGenuses(new QueryOptions { });
            var species = repository.Species.GetAllSpecies(options);
            return View("Index", species);
        }

        [HttpPost]
        public IActionResult UpdateSpecies(long speciesId, SpeciesForUpdateDto species)
        {
            var speciesEntity = repository.Species.GetSpecies(speciesId, true);
            mapper.Map(species, speciesEntity);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteSpecies(Species species)
        {
            repository.Species.DeleteSpecies(species);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
