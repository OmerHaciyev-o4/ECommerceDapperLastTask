using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDapper.Domain.Entities.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.HasKey(o => o.Id);
            this.ToTable("Orders");

            this.Property(o => o.Id)
                .IsRequired()
                .HasColumnName("Id");

            this.Property(o => o.Date)
                .IsRequired()
                .HasColumnName("Date");

            this.Property(o => o.Quantity)
                .IsRequired()
                .HasColumnName("Quantity");


            this.Property(o => o.Price)
                .IsRequired()
                .HasColumnName("Price");

            this.Property(o => o.ProductId)
                .IsRequired()
                .HasColumnName("ProductId");

            this.Property(o => o.UserId)
                .IsRequired()
                .HasColumnName("UserId");
        }
    }
}