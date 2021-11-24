using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Web.Models
{
    public class MonthlyGiroViewModelWDate
    {
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public decimal totalIncome { get; set; }
        public List<Bills> Bills { get; set; }
        public decimal totalExpense { get; set; }
        public List<StorePartner> StorePartners { get; set; }
        public decimal Total { get; set; }

        //public DateTime StartedDate { get; set; }
        //public DateTime EndDate { get; set; }
    }
}
