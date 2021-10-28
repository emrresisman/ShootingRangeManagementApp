using Microsoft.EntityFrameworkCore;
using ShootingRangeManagementApp.Models;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.EFCore.Context
{
    public class StoreContext:DbContext
    {
        public DbSet<Bills> Bills { get; set; }
        public DbSet<DailyStoreGiro> DailyStoreGiros { get; set; }
        public DbSet<MonthlyStoreGiro> MonthlyStoreGiros { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StorePartner> StorePartners { get; set; }
        public DbSet<StoreStocks> StoreStocks { get; set; }
        public DbSet<AppUser> Users { get; set; }
        
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public StoreContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration(new ()); konfigürasyonları ekle
            base.OnModelCreating(modelBuilder);
        }
    }
}
