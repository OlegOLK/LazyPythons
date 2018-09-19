using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LazyPythons.Abstractions.Models;
using LazyPythons.Sql.ConfigMappings;
using LazyPythons.Sql.Data;
using LazyPythons.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LazyPythons.Sql.Initialization
{
    public class SqlInitializer : SqlRepository
    {
        public SqlInitializer(DbContextOptions<LazyPhytonsContext> options) : base(options)
        {
           
        }

        public void Initialize()
        {
            using (var context = CreateLazyPhytonsContext())
            {
                if (context.Caffes.Any())
                {
                    return;
                }
            }

            CreateTestCaffes();
            CreateTestMenu();
            CreateTestDishes();
            CreateTestBeverages();
        }

        public void CreateTestCaffes()
        {
            using (var context = CreateLazyPhytonsContext())
            {
                context.Caffes.Add(new Caffe()
                {
                    Description = "@Test Description",
                    LinkToImage = "@TestLink",
                    Name = "@TestName",
                    Notes = "@Notes",
                    Rating = 5,
                    IsFreeBeverages = true,
                    Latitude = (long) (48.466838),
                    Longitude = (long) (35.048002),
                    Lunch2Price = 110,
                    Lunch3Price = 120,
                    DistanceFromOffice = 100
                });

                context.SaveChanges();
            }
        }

        public void CreateTestMenu()
        {
            using (var context = CreateLazyPhytonsContext())
            {
                var cafe = context.Caffes.FirstOrDefault(x => x.Name.Equals("@TestName"));
                if (cafe == null)
                {
                    return;
                }

                context.Menus.Add(new Menu()
                {

                    Notes = "@Notes",
                    Caffe = cafe
                });
                context.SaveChanges();
            }
        }

        public void CreateTestDishes()
        {
            using (var context = CreateLazyPhytonsContext())
            {
                var menu = context.Menus.FirstOrDefault();
                if (menu == null)
                {
                    return;
                }

                context.Dishes.Add(new Dish()
                {

                    Notes = "@Notes",
                    Category = DishCategories.Salad,
                    Name = "@Cesar",
                    LinkToImage = "@Image",
                    Menu = menu
                });
                context.SaveChanges();
            }
        }

        public void CreateTestBeverages()
        {
            using (var context = CreateLazyPhytonsContext())
            {
                var menu = context.Menus.FirstOrDefault();
                if (menu == null)
                {
                    return;
                }

                context.Beverages.Add(new Beverage()
                {

                    Notes = "@Notes",
                    Name = "@Tea",
                    LinkToImage = "@Image",
                    Menu = menu
                });
                context.SaveChanges();
            }
        }
    }
}
