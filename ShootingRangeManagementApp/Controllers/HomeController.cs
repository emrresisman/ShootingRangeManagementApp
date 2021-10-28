using Microsoft.AspNetCore.Mvc;
using ShootingRangeManagementApp.Core.UnitOfWork;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShootingRangeManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public HomeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var StoreRepository = _unitOfWork.StoreRepository;
            return View(StoreRepository.GetStores());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Store store)
        {
            var UserRepository = _unitOfWork.StoreRepository;
            UserRepository.Create(store);
            _unitOfWork.Complete();
            return RedirectToAction("Index"); 
        }
        public IActionResult Detail(int Id)
        {
            DailyStoreGiro dailyStoreGiro = new DailyStoreGiro();
           
            var StoreRepository = _unitOfWork.StoreRepository;
            var storeDetail = StoreRepository.GetStore(Id);
            return View(storeDetail);
        }
        public IActionResult Delete(int id)
        {
            var storeRepository = _unitOfWork.StoreRepository;
            storeRepository.Delete(id);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
