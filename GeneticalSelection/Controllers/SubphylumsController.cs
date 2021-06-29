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
    public class SubphylumsController : Controller
    {
        private IRepositoryManager repository;
        private ILoggerManager logger;
        private IMapper mapper;
        public SubphylumsController(IRepositoryManager _repository,
            ILoggerManager _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }
        public IActionResult Index(QueryOptions options)
        {
            var subphylums = repository.Subphylum.GetAllSubphylums(options);
            ViewBag.Phylums = repository.Phylum.GetAllPhylums(new QueryOptions { });
            return View(subphylums);
        }

        [HttpPost]
        public IActionResult CreateSubphylum(Subphylum subphylum)
        {
            repository.Subphylum.CreateSubphylum(subphylum.PhylumId, subphylum);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditSubphylum(QueryOptions options, long subphylumId)
        {
            ViewBag.SubphylumId = subphylumId;
            ViewBag.Phylums = repository.Phylum.GetAllPhylums(new QueryOptions { });
            var subphylums = repository.Subphylum.GetAllSubphylums(options);
            return View("Index", subphylums);
        }

        [HttpPost]
        public IActionResult UpdateSubphylum(long subphylumId, SubphylumForUpdateDto subphylum)
        {
            var subphylumEntity = repository.Subphylum.GetSubphylum(subphylumId, true);
            mapper.Map(subphylum, subphylumEntity);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteSubphylum(Subphylum subphylum)
        {
            repository.Subphylum.DeleteSubphylum(subphylum);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
