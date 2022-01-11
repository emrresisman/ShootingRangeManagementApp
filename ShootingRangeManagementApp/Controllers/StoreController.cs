using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShootingRangeManagementApp.Core.DailyGiro;
using ShootingRangeManagementApp.Core.UnitOfWork;
using ShootingRangeManagementApp.Dtos.DailyStoreGiroDtos;
using ShootingRangeManagementApp.Dtos.StoreDtos;
using ShootingRangeManagementApp.Dtos.StorePartnerDtos;
using ShootingRangeManagementApp.EFCore.Context;
using ShootingRangeManagementApp.Models.Entities;
using ShootingRangeManagementApp.Models.ViewModels;
using ShootingRangeManagementApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Web.Controllers
{
    
    public class StoreController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _manager;
        private readonly RoleManager<AppRole> _roleManager;


        public StoreController(UnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> manager, RoleManager<AppRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _manager = manager;
            _roleManager = roleManager;
        }
      
        public async Task<IActionResult> Index(int id)
        {
            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            


            var StoreRepository = _unitOfWork.StoreRepository;
            var DailyGiroRepository = _unitOfWork.DailyGiroRepository;
            var StockRepository = _unitOfWork.StockRepository;
            var BillRepository = _unitOfWork.BillRepository;

            StoreViewModel storeViewModel = new StoreViewModel()
            {
                Id = id,
                Store = StoreRepository.GetStore(id),
                DailyStoreGiros = DailyGiroRepository.GetDailyGiros().ToList(),
                StoreStocks = StockRepository.GetStock(id)
            };

            //var storeDetail = StoreRepository.GetStore(Id);
            var currentStore=StoreRepository.GetStore(id);
            
           

            var currentUser = await _manager.GetUserAsync(User);
            var UserWithStores = _manager.Users.Where(z => z.Id == currentUser.Id).Include(o => o.AppUserStores).ToList();
            var storesAdmin = UserWithStores.Select(o => o.AppUserStores);
            var Id = currentUser.StoreId;
            if (User.IsInRole("Member")&&!User.IsInRole("Admin"))
            {
                if (id != Id)
                {
                    throw new ArgumentException("Access denied.You can't access this store.");
                }
            }
            else if (User.IsInRole("LocaleAdmin"))
            {

                var userStores = UserWithStores.SelectMany(o => o.AppUserStores).ToList();
                var idList = userStores.Select(o => o.StoreId).ToList();

                foreach (var UserId in idList)
                {
                    if (id == UserId)
                    {
                        return View(storeViewModel);
                    }
                    else if (id != UserId)
                    {
                        throw new ArgumentException("Access denied.You can't access this store");
                    }
                }
            }
           
            ViewData["Id"] = id;
            return View(storeViewModel);
        }
        //public IActionResult GetDailyGiros(int id)
        //{
        //    var DailyGiroRepository = _unitOfWork.DailyGiroRepository;
        //    var DailyStoreGiros = DailyGiroRepository.FindStoreDailyGiros(id).ToList();
        //    return View(DailyStoreGiros);
        //}
     
        public IActionResult DailyStoreGiroDataTables(int id)
        {
            ViewData["Id"] = id;
            var DailyGiroRepository = _unitOfWork.DailyGiroRepository;
            var DailyStoreGiros = DailyGiroRepository.FindStoreDailyGiros(id).ToList();
            return View(DailyStoreGiros);
        }
        
        public IActionResult DailyBillsDataTable(int id)
        {
            ViewData["Id"] = id;
            var BillRepository = _unitOfWork.BillRepository;
            var DailyBills = BillRepository.FindStoreBills(id).ToList();
            return View(DailyBills);
        }

        //public IActionResult CreateDailyGiro(int id)
        //{

        //    ViewData["Id"] = id;

        //    return View();

        //}
        //[HttpPost]
        //public IActionResult CreateDailyGiro(CreateDailyGiroDto createDailyGiroDto)
        //{
        //    var dailyGiroRepository = _unitOfWork.DailyGiroRepository;
        //    DailyStoreGiro dailyStoreGiro = new DailyStoreGiro();
        //    _mapper.Map(createDailyGiroDto, dailyStoreGiro);
        //    dailyGiroRepository.Create(dailyStoreGiro);
        //    _unitOfWork.Complete();
        //    return RedirectToAction("Index");

        //}
        //[HttpPost]
        //public IActionResult CreateDailyGiro(DailyStoreGiro dailyStoreGiro)
        //{

        //    var dailyGiroRepository = _unitOfWork.DailyGiroRepository;
        //    dailyGiroRepository.Create(dailyStoreGiro);
        //    _unitOfWork.Complete();
        //    return RedirectToAction("Index");
        //}

        public IActionResult EditDailyBill(int id)
        {

            var billRepository = _unitOfWork.BillRepository;
            var dailyBill = billRepository.GetBill(id);

            return View(dailyBill);
        }

        [HttpPost]
        public IActionResult EditDailyBill(EditDailyBillDto editDailyBillDto)
        {
            //var dailyGiroRepository = _unitOfWork.DailyGiroRepository;
            //var dailyGiro = dailyGiroRepository.GetDailyGiro(dailyStoreGiroDto.Id);
            //EditStoreDto editedStoreDto = new EditStoreDto();

            //_mapper.Map(dailyStoreGiroDto, dailyGiro);
            //storeRepository.EditStore(store);


            if (ModelState.IsValid)
            {
                var billRepository = _unitOfWork.BillRepository;
                var dailyBill = billRepository.GetBill(editDailyBillDto.StoreId);
                _mapper.Map(editDailyBillDto, dailyBill);
            }

            //EditStoreDto editedStoreDto = new EditStoreDto();

            //_mapper.Map(storeDto, store);
            //storeRepository.EditStore(store);
            _unitOfWork.Complete();
            return RedirectToAction("DailyBillsDataTable", "Store", new { Id = editDailyBillDto.StoreId });
        }
        public IActionResult EditDailyStoreGiro(int id)
        {
            var dailyGiroRepository = _unitOfWork.DailyGiroRepository;
            DailyStoreGiro dailyStoreGiro = dailyGiroRepository.GetDailyGiro(id);

            return View(dailyStoreGiro);
        }
      
        [HttpPost]
        public IActionResult EditDailyStoreGiro(EditDailyStoreGiroDto dailyStoreGiroDto)
        {
            //var dailyGiroRepository = _unitOfWork.DailyGiroRepository;
            //var dailyGiro = dailyGiroRepository.GetDailyGiro(dailyStoreGiroDto.Id);
            //EditStoreDto editedStoreDto = new EditStoreDto();

            //_mapper.Map(dailyStoreGiroDto, dailyGiro);
            //storeRepository.EditStore(store);
           

            if (ModelState.IsValid)
            {
                var DailyGiroRepository = _unitOfWork.DailyGiroRepository;
                var dailyGiro = DailyGiroRepository.GetDailyGiro(dailyStoreGiroDto.StoreId);
                _mapper.Map(dailyStoreGiroDto, dailyGiro);
            }

            //EditStoreDto editedStoreDto = new EditStoreDto();

            //_mapper.Map(storeDto, store);
            //storeRepository.EditStore(store);
            _unitOfWork.Complete();
            return RedirectToAction("DailyStoreGiroDataTables", "Store", new { Id = dailyStoreGiroDto.StoreId });
        }
      
        public IActionResult DeleteDailyStoreGiro(int id)
        {
            var dailyGiroRepository = _unitOfWork.DailyGiroRepository;
            dailyGiroRepository.Delete(id);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
    }
        
        public IActionResult CreateDailyBill(int id)
        {
            ViewData["Id"] = id;

            return View();

        }
       
        [HttpPost]
        public IActionResult CreateDailyBill(Bills bills)
        {
            var billRepository = _unitOfWork.BillRepository;
            billRepository.Create(bills);
            _unitOfWork.Complete();
            return RedirectToAction("Index","Store", new { Id = bills.StoreId });
        }

        //public IActionResult GetDailyBills(int id)
        //{
        //    var BillRepository = _unitOfWork.BillRepository;
        //    var DailyBills = BillRepository.FindStoreBills(id).ToList();
        //    return View(DailyBills);
        //}
        
        public IActionResult AddStorePartner(int id)
        {

            ViewData["Id"] = id;
            return View();

        }
        
        [HttpPost]
        public IActionResult AddStorePartner(CreateStorePartnerDto createStorePartnerDto)
        {
            var storePartnerRepository = _unitOfWork.StorePartnerRepository;
            StorePartner storePartner = new StorePartner();
            _mapper.Map(createStorePartnerDto, storePartner);
            storePartnerRepository.Create(storePartner);
            
           
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Store", new { Id = storePartner.StoreId });
        }
        
        public IActionResult DeleteStorePartner(int id)
        {
            var storePartnerRepository = _unitOfWork.StorePartnerRepository;
            var deletedPartner = storePartnerRepository.GetStorePartner(id);
            storePartnerRepository.Delete(id);
            _unitOfWork.Complete();  // Deleteden sonra routingde hata var düzelt !!!!
            return RedirectToAction("Index", "Store", new { Id = deletedPartner.StoreId });
        }
        public IActionResult EditStorePartner(int id)
        {
            var storePartnerRepository = _unitOfWork.StorePartnerRepository;
            var storePartner=storePartnerRepository.GetStorePartner(id);
            ViewData["Id"] = id;
            return View(storePartner);
        }
        [HttpPost]
        public IActionResult EditStorePartner(EditStorePartnerDto editStorePartnerDto)
        {
            var StorePartnerRepository = _unitOfWork.StorePartnerRepository;
            var editedStorePartner = StorePartnerRepository.GetStorePartner(editStorePartnerDto.Id);
            //EditStoreDto editedStoreDto = new EditStoreDto();
             
            _mapper.Map(editStorePartnerDto, editedStorePartner);
            //storeRepository.EditStore(store);
            _unitOfWork.Complete();
            return RedirectToAction("GetStorePartners","Store", new { Id = editedStorePartner.StoreId });
        }

        public IActionResult GetStorePartners(int id)
        {
            var storePartnersRepository = _unitOfWork.StorePartnerRepository;
            var storePartners = storePartnersRepository.FindStorePartners(id).ToList();
            return View(storePartners);
        }
        
        public IActionResult CalculateMonthlyGiro(int id)
        {
            ViewData["Id"] = id;
            var dailyGiroRepository = _unitOfWork.DailyGiroRepository;
            var dailyGiros = dailyGiroRepository.FindStoreDailyGiros(id);
            var dailyBillRepository = _unitOfWork.BillRepository;
            var dailyBills = dailyBillRepository.FindStoreBills(id);
            var storePartnerRepository = _unitOfWork.StorePartnerRepository;
            var storePartners = storePartnerRepository.FindStorePartners(id);
            var storeRepository = _unitOfWork.StoreRepository;
            var store = storeRepository.GetStore(id);
            MonthlyGiroViewModel monthlyGiroViewModel = new MonthlyGiroViewModel();
            monthlyGiroViewModel.StorePartners = new List<StorePartner>();

            monthlyGiroViewModel.Store = store;
         

            monthlyGiroViewModel.totalIncome = dailyGiros.Sum(o => o.Cash + o.CreditCart);
            monthlyGiroViewModel.totalExpense = dailyBills.Sum(o => o.BillCost);

            monthlyGiroViewModel.Total = monthlyGiroViewModel.totalIncome - monthlyGiroViewModel.totalExpense;
            List<StorePartner> storePartnerList = new List<StorePartner>();
            foreach (var storePartner in storePartners)
            {
                storePartner.TotalAmount=monthlyGiroViewModel.Total * storePartner.PaymentRate /100 ;
                monthlyGiroViewModel.StorePartners.Add(storePartner);
            }

            return View(monthlyGiroViewModel);

            
        }
        
        [HttpPost]
        public IActionResult CalculateMonthlyGiro(MonthlyGiroViewModel monthlyGiroViewModel, DateTime startDate,DateTime endDate)
        {
            
            endDate.AddDays(1);
          
            var id = monthlyGiroViewModel.StoreId;
            var dailyGiroRepository = _unitOfWork.DailyGiroRepository;
            var dailyGiros = dailyGiroRepository.FindStoreDailyGiros(id);
            var q = from dailyGiro in dailyGiros where dailyGiro.Date >= startDate && dailyGiro.Date < endDate
                    select dailyGiro;
             
            //dailyGiros = (from x in dailyGiros where (x.Date <= startDate) && (x.Date >= endDate) select x).ToList();

            var dailyBillRepository = _unitOfWork.BillRepository;
            var dailyBills = dailyBillRepository.FindStoreBills(id);

            var f = from dailyBill in dailyBills
                    where dailyBill.Date >= startDate && dailyBill.Date < endDate
                    select dailyBill;

            var storePartnerRepository = _unitOfWork.StorePartnerRepository;
            var storePartners = storePartnerRepository.FindStorePartners(id);
            var storeRepository = _unitOfWork.StoreRepository;
            var store = storeRepository.GetStore(id);

            monthlyGiroViewModel.StorePartners = new List<StorePartner>();

            monthlyGiroViewModel.Store = store;


            monthlyGiroViewModel.totalIncome = q.Sum(o => o.Cash + o.CreditCart);
            monthlyGiroViewModel.totalExpense = f.Sum(o => o.BillCost);

            monthlyGiroViewModel.Total = monthlyGiroViewModel.totalIncome - monthlyGiroViewModel.totalExpense;
            List<StorePartner> storePartnerList = new List<StorePartner>();
            foreach (var storePartner in storePartners)
            {
                storePartner.TotalAmount = monthlyGiroViewModel.Total * storePartner.PaymentRate / 100;
                monthlyGiroViewModel.StorePartners.Add(storePartner);
            }

            return View(monthlyGiroViewModel);


        }
        //public IActionResult CalculateMonthlyGiroWDates(int id)
        //{
        //    ViewData["Id"] = id;
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CalculateMonthlyGiroWDates(MonthlyGiroViewModel monthlyGiroViewModel,DateTime startDate, DateTime endDate)
        //{
           
            
           
        //}
    }
   
}
