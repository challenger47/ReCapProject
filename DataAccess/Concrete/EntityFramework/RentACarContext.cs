﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

         optionsBuilder.UseSqlServer(@"server=DESKTOP-JAMSI54\SQLEXPRESS;Database=RentACar;Trusted_Connection=true");

        }
        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color>Colors { get; set; }
        public DbSet<Customer>Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
