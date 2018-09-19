﻿using System;
using System.Collections.Generic;
using System.Text;
using LazyPythons.Abstractions.Models;
using LazyPythons.Sql.Data;
using Microsoft.EntityFrameworkCore;

namespace LazyPythons.Sql
{
    public class LazyPhytonsContext : DbContext
    {
        protected string ConnectionString { get; }

        public LazyPhytonsContext(DbContextOptions<LazyPhytonsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Caffe> Caffes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caffe>()
                .HasOne(caffe => caffe.Menu)
                .WithOne(menu => menu.Caffe)
                .HasForeignKey<Menu>(menu => menu.CaffeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dish>()
                .HasOne(dish => dish.Menu)
                .WithMany(menu => menu.Dishes)
                .HasForeignKey(dish => dish.MenuId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Beverage>()
                .HasOne(beverage => beverage.Menu)
                .WithMany(menu => menu.Beverages)
                .HasForeignKey(beverage => beverage.MenuId)
                .OnDelete(DeleteBehavior.Cascade); ;

            modelBuilder.Entity<Dish>()
                .Property(dish => dish.Category)
                .HasConversion(category => category.ToString(),
                    category => (DishCategories)Enum.Parse(typeof(DishCategories), category));
        }
    }
}
