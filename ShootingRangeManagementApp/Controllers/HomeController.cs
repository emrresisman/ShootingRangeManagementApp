using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShootingRangeManagementApp.Core.UnitOfWork;
using ShootingRangeManagementApp.Dtos.StoreDtos;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShootingRangeManagementApp.Controllers
{
    
    public class HomeController : Controller
    {
        // USER REMEMBER ME SEÇİLİYKEN SİTEYİ AÇTIĞINDA HOME INDEXE GİRMEYE ÇALIŞIYOR ÇÖZÜM BUL.
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _manager;

        public HomeController(UnitOfWork unitOfWork,IMapper mapper,UserManager<AppUser> manager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _manager.GetUserAsync(User);
            var Id = currentUser.StoreId;
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Store", new { @id = Id });
            }
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
        public IActionResult Edit(int id)
        {
            var storeRepository = _unitOfWork.StoreRepository;
            Store store = storeRepository.GetStore(id);
            
            return View(store);
        }
        [HttpPost]
        public IActionResult Edit(EditStoreDto storeDto)
        {
            var storeRepository = _unitOfWork.StoreRepository;
            var store = storeRepository.GetStore(storeDto.StoreId);
            //EditStoreDto editedStoreDto = new EditStoreDto();

            _mapper.Map(storeDto, store);
            //storeRepository.EditStore(store);
            _unitOfWork.Complete();
            return View("Index");
        }
    }
}
