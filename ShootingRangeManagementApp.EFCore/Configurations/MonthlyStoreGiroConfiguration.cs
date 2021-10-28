using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.EFCore.Configurations
{
    public class MonthlyStoreGiroConfiguration : IEntityTypeConfiguration<MonthlyStoreGiro>
    {
        public void Configure(EntityTypeBuilder<MonthlyStoreGiro> builder)
        {
            
            builder.Property(x => x.TotalAmountMonthly).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Date).HasDefaultValueSql("getdate()");
        }
    }
}
