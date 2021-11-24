using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Web.Models
{
    public class MonthlyGiroViewModel
    {

        public int StoreId { get; set; }
        public Store Store { get; set; }
        
        public decimal totalIncome { get; set; }
        public List<Bills> Bills { get; set; }
        public decimal totalExpense { get; set; }
        public List<StorePartner> StorePartners { get; set; }
        public decimal Total { get; set; }
        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }

    }
}
