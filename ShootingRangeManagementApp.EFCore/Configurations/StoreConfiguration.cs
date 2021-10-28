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
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(x => x.Address).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Balance).HasMaxLength(300).IsRequired();
            builder.Property(x => x.StoreName).HasMaxLength(300).IsRequired();
        }
    }
}
