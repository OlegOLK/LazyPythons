using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LazyPythons.Abstractions.Models;
using LazyPythons.Sql.Data;

namespace LazyPythons.Sql.Initialization
{
    public class SqlInitializer
    {
        private readonly LazyPhytonsContext _context;
        public SqlInitializer(LazyPhytonsContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            if (_context.Caffes.Any())
            {
                return;
            }
            CreateTestCaffes();
            CreateTestMenu();
            CreateTestDishes();
            CreateTestBeverages();
        }

        public void CreateTestCaffes()
        {
            _context.Caffes.Add(new Caffe()
            {
                Description = "@Test Description",
                LinkToImage = "@TestLink",
                Name = "@TestName",
                Notes = "@Notes",
                Rating = 5,
                IsFreeBeverages = true,
                Latitude = (long)(48.466838),
                Longitude = (long)(35.048002),
                Lunch2Price = 110,
                Lunch3Price = 120
                //Location = "48.446431, 35.000474"
            });

            _context.SaveChanges();
        }

        public void CreateTestMenu()
        {
            var cafe = _context.Caffes.FirstOrDefault(x => x.Name.Equals("@TestName"));
            if (cafe == null)
            {
                return;
            }
            _context.Menus.Add(new Menu()
            {

                Notes = "@Notes",
                Caffe = cafe
            });
            _context.SaveChanges();
        }

        public void CreateTestDishes()
        {
            var menu = _context.Menus.FirstOrDefault();
            if (menu == null)
            {
                return;
            }
            _context.Dishes.Add(new Dish()
            {

                Notes = "@Notes",
                Category = DishCategories.Salad,
                Name = "@Cesar",
                LinkToImage = "@Image",
                Menu = menu
            });
            _context.SaveChanges();
        }

        public void CreateTestBeverages()
        {
            var menu = _context.Menus.FirstOrDefault();
            if (menu == null)
            {
                return;
            }
            _context.Beverages.Add(new Beverage()
            {

                Notes = "@Notes",
                Name = "@Tea",
                LinkToImage = "@Image",
                Menu = menu
            });
            _context.SaveChanges();
        }
    }
}
