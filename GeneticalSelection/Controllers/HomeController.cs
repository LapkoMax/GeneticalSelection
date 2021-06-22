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
            var kingdomsDto = mapper.Map<IEnumerable<KingdomDto>>(kingdoms);
            return View(kingdomsDto);
        }

        [HttpPost]
        public IActionResult CreateKingdom(KingdomForCreationDto kingdom)
        {
            var kingdomEntity = mapper.Map<Kingdom>(kingdom);
            repository.Kingdom.CreateKingdom(kingdomEntity);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
