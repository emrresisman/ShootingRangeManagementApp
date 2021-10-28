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
    class StorePartnerConfiguration : IEntityTypeConfiguration<StorePartner>
    {
        public void Configure(EntityTypeBuilder<StorePartner> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x => x.PaymentRate).HasMaxLength(300).IsRequired();
            builder.Property(x => x.TotalAmount).HasMaxLength(300).IsRequired();
        }
    }
}
