using System;
using ApiDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNet.Data
{
   public class DatabaseContext : DbContext {

      public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
      {}

      public DbSet<Person> People { get; set; }
      public DbSet<Product> Products { get; set; }
      public DbSet<Purchase> Purchases { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
      }
   }
}
