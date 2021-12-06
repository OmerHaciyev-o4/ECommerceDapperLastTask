using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDapper.Domain.Entities.Mapping
{
    class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id)
                .IsRequired()
                .HasColumnName("Id");

            this.Property(p => p.Code)
                .IsRequired()
                .HasColumnName("Code")
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UQ_Products_Code") { IsUnique = true }));

            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("Name");

            this.Property(p => p.Quantity)
                .IsRequired()
                .HasColumnName("Quantity");

            this.Property(p => p.Price)
                .IsRequired()
                .HasColumnName("Price");
        }
    }
}
