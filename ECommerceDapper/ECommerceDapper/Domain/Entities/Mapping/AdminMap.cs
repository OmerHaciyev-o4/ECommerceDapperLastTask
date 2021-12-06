using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDapper.Domain.Entities.Mapping
{
    public class AdminMap : EntityTypeConfiguration<Admin>
    {
        public AdminMap()
        {
            this.HasKey(a => a.Id);
            this.Property(a => a.Id)
                .IsRequired()
                .HasColumnName("Id");

            this.Property(a => a.Username)
                .IsRequired()
                .HasColumnName("Username");

            this.Property(a => a.Password)
                .IsRequired()
                .HasColumnName("Password");
        }
    }
}
