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
    public class StoreStocksConfiguration : IEntityTypeConfiguration<StoreStocks>
    {
        public void Configure(EntityTypeBuilder<StoreStocks> builder)
        {
            builder.Property(x => x.BrokenGunCount).HasMaxLength(30).IsRequired();
            builder.Property(x => x.WorkingGunCount).HasMaxLength(30).IsRequired();
            builder.Property(x => x.BulletBoxCount).HasMaxLength(30).IsRequired();
        }
    }
}
