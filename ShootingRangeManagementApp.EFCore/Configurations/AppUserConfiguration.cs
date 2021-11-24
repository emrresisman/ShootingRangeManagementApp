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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //builder.Property(x => x.Username).HasMaxLength(300).IsRequired();
            //builder.Property(x => x.FullName).HasMaxLength(300).IsRequired();
            //builder.Property(x => x.Password).HasMaxLength(50).IsRequired();

        }
    }
}
