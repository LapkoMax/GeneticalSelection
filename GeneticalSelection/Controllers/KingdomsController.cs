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
    public class KingdomsController : Controller
    {
        private IRepositoryManager repository;
        private ILoggerManager logger;
        private IMapper mapper;
        public KingdomsController(IRepositoryManager _repository,
            ILoggerManager _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }
        public IActionResult Index(QueryOptions options)
        {
            var kingdoms = repository.Kingdom.GetAllKingdoms(options);
            return View(kingdoms);
        }

        [HttpPost]
        public IActionResult CreateKingdom(Kingdom kingdom)
        {
            repository.Kingdom.CreateKingdom(kingdom);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditKingdom(QueryOptions options, long kingdomId)
        {
            ViewBag.KingdomId = kingdomId;
            var kingdoms = repository.Kingdom.GetAllKingdoms(options);
            return View("Index", kingdoms);
        }

        [HttpPost]
        public IActionResult UpdateKingdom(long kingdomId, KingdomForUpdateDto kingdom)
        {
            var kingdomEntity = repository.Kingdom.GetKingdom(kingdomId, true);
            mapper.Map(kingdom, kingdomEntity);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteKingdom(Kingdom kingdom)
        {
            repository.Kingdom.DeleteKingdom(kingdom);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
