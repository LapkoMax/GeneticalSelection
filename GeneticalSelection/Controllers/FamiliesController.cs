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
    public class FamiliesController : Controller
    {
        private IRepositoryManager repository;
        private ILoggerManager logger;
        private IMapper mapper;
        public FamiliesController(IRepositoryManager _repository,
            ILoggerManager _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }
        public IActionResult Index(QueryOptions options)
        {
            var families = repository.Family.GetAllFamilies(options);
            ViewBag.Orders = repository.Order.GetAllOrders(new QueryOptions { });
            return View(families);
        }

        [HttpPost]
        public IActionResult CreateFamily(Family family)
        {
            repository.Family.CreateFamily(family.OrderId, family);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditFamily(QueryOptions options, long familyId)
        {
            ViewBag.FamilyId = familyId;
            ViewBag.Orders = repository.Order.GetAllOrders(new QueryOptions { });
            var families = repository.Family.GetAllFamilies(options);
            return View("Index", families);
        }

        [HttpPost]
        public IActionResult UpdateFamily(long familyId, FamilyForUpdateDto family)
        {
            var familyEntity = repository.Family.GetFamily(familyId, true);
            mapper.Map(family, familyEntity);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteFamily(Family family)
        {
            repository.Family.DeleteFamily(family);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
