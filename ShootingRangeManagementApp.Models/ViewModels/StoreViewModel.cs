using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Models.ViewModels
{
    public class StoreViewModel
    {
     
        public int Id { get; set; }
        public Store Store { get; set; }
        public List<DailyStoreGiro> DailyStoreGiros { get; set; }
        public StoreStocks StoreStocks { get; set; }
        public List<Bills> Bills { get; set; }
        

        //public StoreStocks StoreStock { get; set; }


    }
}
