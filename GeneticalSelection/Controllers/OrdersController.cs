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
    public class OrdersController : Controller
    {
        private IRepositoryManager repository;
        private ILoggerManager logger;
        private IMapper mapper;
        public OrdersController(IRepositoryManager _repository,
            ILoggerManager _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }
        public IActionResult Index(QueryOptions options)
        {
            var orders = repository.Order.GetAllOrders(options);
            ViewBag.Classes = repository.Class.GetAllClasses(new QueryOptions { });
            return View(orders);
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            repository.Order.CreateOrder(order.ClassId, order);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditOrder(QueryOptions options, long orderId)
        {
            ViewBag.OrderId = orderId;
            ViewBag.Classes = repository.Class.GetAllClasses(new QueryOptions { });
            var orders = repository.Order.GetAllOrders(options);
            return View("Index", orders);
        }

        [HttpPost]
        public IActionResult UpdateOrder(long orderId, OrderForUpdateDto order)
        {
            var orderEntity = repository.Order.GetOrder(orderId, true);
            mapper.Map(order, orderEntity);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteOrder(Order order)
        {
            repository.Order.DeleteOrder(order);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
