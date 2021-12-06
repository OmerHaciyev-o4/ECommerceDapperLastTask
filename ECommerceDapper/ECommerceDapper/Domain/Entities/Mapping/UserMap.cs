using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDapper.Domain.Entities.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(u => u.Id);
            this.Property(u => u.Id)
                .IsRequired()
                .HasColumnName("Id");

            this.Property(u => u.Username)
                .IsRequired()
                .HasColumnName("Username");

            this.Property(u => u.Password)
                .IsRequired()
                .HasColumnName("Password");
        }
    }
}
