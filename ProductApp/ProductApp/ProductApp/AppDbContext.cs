using Microsoft.EntityFrameworkCore;
using ProductApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        //private readonly string _dbPath;

      public AppDbContext()
        {
            //_dbPath = dbPath;
            this.Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) 
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Product.db");
            optionBuilder.UseSqlite($"Filename = {dbPath}");



        }




    }
}
