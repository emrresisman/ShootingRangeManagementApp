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
        public DailyStoreGiro DailyStoreGiro { get; set; }
        public MonthlyStoreGiro MonthlyStoreGiro { get; set; }
        public StoreStocks StoreStock { get; set; }
        public StorePartner StorePartner { get; set; }
        public Bills Bills { get; set; }
    }
}
