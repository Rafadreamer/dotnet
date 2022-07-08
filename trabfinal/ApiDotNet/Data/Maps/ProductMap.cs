using System;
using ApiDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                    .HasColumnName("idproduto")
                    .UseIdentityColumn();

            builder.Property(c => c.Name)
                    .HasColumnName("nome");

            builder.Property(c => c.CodErp)
                    .HasColumnName("codeerp");

            builder.Property(c => c.Price)
                    .HasColumnName("preco");

            builder.HasMany(x => x.Purchases)
                    .WithOne(p => p.Product)
                    .HasForeignKey(x => x.ProductId);
        }
    }
}