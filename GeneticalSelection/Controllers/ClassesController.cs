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
    public class ClassesController : Controller
    {
        private IRepositoryManager repository;
        private ILoggerManager logger;
        private IMapper mapper;
        public ClassesController(IRepositoryManager _repository,
            ILoggerManager _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }
        public IActionResult Index(QueryOptions options)
        {
            var classes = repository.Class.GetAllClasses(options);
            ViewBag.Subphylums = repository.Subphylum.GetAllSubphylums(new QueryOptions { });
            return View(classes);
        }

        [HttpPost]
        public IActionResult CreateClass(Class cl)
        {
            repository.Class.CreateClass(cl.SubphylumId, cl);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditClass(QueryOptions options, long classId)
        {
            ViewBag.ClassId = classId;
            ViewBag.Subphylums = repository.Subphylum.GetAllSubphylums(new QueryOptions { });
            var classes = repository.Class.GetAllClasses(options);
            return View("Index", classes);
        }

        [HttpPost]
        public IActionResult UpdateClass(long classId, ClassForUpdateDto cl)
        {
            var classEntity = repository.Class.GetClass(classId, true);
            mapper.Map(cl, classEntity);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteClass(Class cl)
        {
            repository.Class.DeleteClass(cl);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
