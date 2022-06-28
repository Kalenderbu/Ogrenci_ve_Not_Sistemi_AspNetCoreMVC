using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ogrenci_ve_Not_Sistemi_AspNetCoreMVC.Models
{
    
    public class Context : DbContext
    {
        public DbSet<Ogrenciler> ogrencilerTablosu { get; set; }
        public DbSet<Dersler> derslerTablosu { get; set; }

        public DbSet<Notlar> notlarTablosu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connectionstring
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Ogrenci_ve_Not_Db;User Id=postgres;Password=123456;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}