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
    public class GenusesController : Controller
    {
        private IRepositoryManager repository;
        private ILoggerManager logger;
        private IMapper mapper;
        public GenusesController(IRepositoryManager _repository,
            ILoggerManager _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }
        public IActionResult Index(QueryOptions options)
        {
            var genuses = repository.Genus.GetAllGenuses(options);
            ViewBag.Families = repository.Family.GetAllFamilies(new QueryOptions { });
            return View(genuses);
        }

        [HttpPost]
        public IActionResult CreateGenus(Genus genus)
        {
            repository.Genus.CreateGenus(genus.FamilyId, genus);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditGenus(QueryOptions options, long genusId)
        {
            ViewBag.GenusId = genusId;
            ViewBag.Families = repository.Family.GetAllFamilies(new QueryOptions { });
            var genuses = repository.Genus.GetAllGenuses(options);
            return View("Index", genuses);
        }

        [HttpPost]
        public IActionResult UpdateGenus(long genusId, GenusForUpdateDto genus)
        {
            var genusEntity = repository.Genus.GetGenus(genusId, true);
            mapper.Map(genus, genusEntity);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteGenus(Genus genus)
        {
            repository.Genus.DeleteGenus(genus);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
