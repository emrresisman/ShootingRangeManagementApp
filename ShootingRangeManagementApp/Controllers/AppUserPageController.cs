using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShootingRangeManagementApp.Core.UnitOfWork;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Web.Controllers
{
    public class AppUserPageController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<AppUser> _manager;
        public AppUserPageController(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnrivonment, UserManager<AppUser> manager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnrivonment;
            _manager = manager;
        }
        public async Task<IActionResult> Index(int id)
        {
            var currentUser = await _manager.GetUserAsync(User);
            var Id = currentUser.StoreId;
            if (!User.IsInRole("Admin"))
            {
                if (id != Id)
                {
                    throw new ArgumentException("Access denied.You can't access this store.");
                }
            }
            ViewData["Id"] = id;
            return View();
        }
        public async  Task<IActionResult> CreateDailyGiro(int id)
        {
           


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDailyGiro(DailyStoreGiro dailyStoreGiro)
        {
            var dailyGiroRepository = _unitOfWork.DailyGiroRepository;
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(dailyStoreGiro.Image.FileName);
                string extension = Path.GetExtension(dailyStoreGiro.Image.FileName);
                dailyStoreGiro.ImageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Receipt", dailyStoreGiro.ImageName);
                using (var fileStream=new FileStream(path,FileMode.Create))
                {
                    await dailyStoreGiro.Image.CopyToAsync(fileStream);
                }

                dailyGiroRepository.Create(dailyStoreGiro);
                 _unitOfWork.Complete();
                return RedirectToAction("Index", "Store", new { Id = dailyStoreGiro.StoreId });
            }



            return View(dailyStoreGiro);
        }
    }
}
