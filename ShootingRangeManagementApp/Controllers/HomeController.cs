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
using Microsoft.EntityFrameworkCore;


namespace ShootingRangeManagementApp.Controllers
{
    [Authorize]
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
            var StoreRepository = _unitOfWork.StoreRepository;
            var currentUser = await _manager.GetUserAsync(User);
            var UserWithStores = _manager.Users.Where(z => z.Id == currentUser.Id).Include(o => o.AppUserStores).ToList();
            if (User.IsInRole("Member"))
            {
                var Id = currentUser.StoreId;
                return RedirectToAction("Index", "Store", new { @id = Id });
            }
            else if (User.IsInRole("LocaleAdmin"))
            {
                var storeRepository = _unitOfWork.StoreRepository;

                var userStores= UserWithStores.SelectMany(o => o.AppUserStores).ToList();
                var idList=userStores.Select(o => o.StoreId).ToList();
                //var idList=currentUser.AppUserStores.Select(o => o.StoreId).ToList();
                var localstores=storeRepository.GetStoresWithFilterMultiple(idList).ToList();
                return View(localstores);
            }
            else if (User.IsInRole("Admin"))
            {
                
                return View(StoreRepository.GetStores());
            }
            
          
            return View(StoreRepository.GetStores());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Store store)
        {
            var StoreRepository = _unitOfWork.StoreRepository;
            StoreRepository.Create(store);
            
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
            var store = storeRepository.GetStore(id);
           
            return View(store);
        }
        [HttpPost]
        public IActionResult Edit(EditStoreDto storeDto)
        {
            if (ModelState.IsValid)
            {
                var storeRepository = _unitOfWork.StoreRepository;
                var store = storeRepository.GetStore(storeDto.StoreId);
                _mapper.Map(storeDto, store);
            }
          
            //EditStoreDto editedStoreDto = new EditStoreDto();

            //_mapper.Map(storeDto, store);
            //storeRepository.EditStore(store);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
