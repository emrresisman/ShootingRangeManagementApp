using Microsoft.AspNetCore.Mvc;
using ShootingRangeManagementApp.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Web.Controllers
{
    public class GiroController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public GiroController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
        [HttpPost]
        public JsonResult LoadDataDailyGiro(int id)
        {
            var DailyGiroRepository = _unitOfWork.DailyGiroRepository;
            var Data = DailyGiroRepository.FindStoreDailyGiros(id).ToList();
           

            return Json(new {data=Data});
        }
        [HttpPost]
        public JsonResult LoadDataDailyBills(int id)
        {
            var billRepository = _unitOfWork.BillRepository;
            var Data = billRepository.FindStoreBills(id).ToList();


            return Json(new { data = Data });
        }
    }
}
