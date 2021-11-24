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
    public class BillsConfiguration : IEntityTypeConfiguration<Bills>
    {
        public void Configure(EntityTypeBuilder<Bills> builder)
        {
            builder.Property(x => x.BillCost).HasMaxLength(50).IsRequired();
          
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Explanation).HasMaxLength(300).IsRequired();
        }
    }
}
