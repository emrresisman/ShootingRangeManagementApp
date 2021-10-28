using Microsoft.AspNetCore.Mvc;
using ShootingRangeManagementApp.Core.UnitOfWork;
using ShootingRangeManagementApp.EFCore.Context;
using ShootingRangeManagementApp.Models.Entities;
using ShootingRangeManagementApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public StoreController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(int id)
        {
            var StoreRepository = _unitOfWork.StoreRepository;

            StoreViewModel storeViewModel = new StoreViewModel()
            {
                Id = id,
               Store = StoreRepository.GetStore(id),
               
            };
           
            //var storeDetail = StoreRepository.GetStore(Id);

            return View(storeViewModel);
        }
    }
}
