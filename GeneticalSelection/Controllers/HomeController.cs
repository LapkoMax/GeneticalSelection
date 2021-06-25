using AutoMapper;
using GeneticalSelection.LoggerService;
using GeneticalSelection.Models.DataTransferObjects;
using GeneticalSelection.Models.Entities;
using GeneticalSelection.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryManager repository;
        private ILoggerManager logger;
        private IMapper mapper;
        public HomeController(IRepositoryManager _repository,
            ILoggerManager _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            var kingdoms = repository.Kingdom.GetAllKingdoms();
            return View(kingdoms);
        }
        public IActionResult UpdateKingdom(long kingdomId)
        {
            if (kingdomId == 0) return View(new KingdomDto());
            var kingdom = repository.Kingdom.GetKingdom(kingdomId);
            var kingdomDto = mapper.Map<KingdomDto>(kingdom);
            ViewData["kingdomId"] = kingdomId;
            return View(kingdomDto);
        }

        [HttpPost]
        public IActionResult UpdateKingdom(long kingdomId, KingdomForUpdateDto kingdom)
        {
            if(kingdomId == 0)
            {
                var kingdomToAdd = mapper.Map<Kingdom>(kingdom);
                repository.Kingdom.CreateKingdom(kingdomToAdd);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            var kingdomEntity = repository.Kingdom.GetKingdom(kingdomId, true);
            if(kingdomEntity == null)
            {
                logger.LogInfo($"Kingdom with id: {kingdomId} doesn't exist in DB.");
                return RedirectToAction(nameof(Index));
            }
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
