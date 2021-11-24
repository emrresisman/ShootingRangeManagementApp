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
    public class DailyStoreGiroConfiguration : IEntityTypeConfiguration<DailyStoreGiro>
    {
        public void Configure(EntityTypeBuilder<DailyStoreGiro> builder)
        {
            builder.Property(x => x.Image).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Cash).HasMaxLength(300).IsRequired();
            builder.Property(x => x.CreditCart).HasMaxLength(300).IsRequired();
            //builder.Property(x => x.Date).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Date).HasDefaultValue(DateTime.Now);
        }
    }
}
