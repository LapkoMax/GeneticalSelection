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
    public class PhylumsController : Controller
    {
        private IRepositoryManager repository;
        private ILoggerManager logger;
        private IMapper mapper;
        public PhylumsController(IRepositoryManager _repository,
            ILoggerManager _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }
        public IActionResult Index(QueryOptions options)
        {
            var phylums = repository.Phylum.GetAllPhylums(options);
            ViewBag.Kingdoms = repository.Kingdom.GetAllKingdoms(new QueryOptions { });
            return View(phylums);
        }

        [HttpPost]
        public IActionResult CreatePhylum(Phylum phylum)
        {
            repository.Phylum.CreatePhylum(phylum.KingdomId, phylum);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditPhylum(QueryOptions options, long phylumId)
        {
            ViewBag.PhylumId = phylumId;
            var phylums = repository.Phylum.GetAllPhylums(options);
            return View("Index", phylums);
        }

        [HttpPost]
        public IActionResult UpdatePhylum(long phylumId, PhylumForUpdateDto phylum)
        {
            var phylumEntity = repository.Phylum.GetPhylum(phylumId, true);
            mapper.Map(phylum, phylumEntity);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeletePhylum(Phylum phylum)
        {
            repository.Phylum.DeletePhylum(phylum);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
