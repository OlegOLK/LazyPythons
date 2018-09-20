using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LazyPythons.Abstractions.Models;
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

            var caffes = CreateTestCaffes();
            CreateTestMenu(caffes);
            CreateTestDishes();
            CreateTestBeverages();
        }

        public List<Caffe> CreateTestCaffes()
        {
            var chemodanCaffe = new Caffe()
            {
                Description = "«Чемодан» на Железной - оригинальный ресторан Днепропетровска",
                LinkToImage = "@TestLink",
                Name = "Чемодан",
                Notes = "",
                Rating = 5,
                IsFreeBeverages = false,
                Latitude = (long)(48.466869),
                Longitude = (long)(35.048002),
                Lunch2Price = 110,
                Lunch3Price = 120,
                DistanceFromOffice = 800
            };

            var banzaiCaffe = new Caffe()
            {
                Description = " С первого посещения этот японский ресторанчик «Банзай» станет Вашим любимым заведением!",
                LinkToImage = "@TestLink",
                Name = "Банзай",
                Latitude = (long)48.466910,
                Longitude = (long)35.048974,
                Lunch2Price = 95,
                Lunch3Price = 105,
                DistanceFromOffice = 750
            };

            using (var context = CreateLazyPhytonsContext())
            {
                context.Caffes.AddRange(new List<Caffe> { chemodanCaffe, banzaiCaffe });

                context.SaveChanges();
                return context.Caffes.ToList();
            }
        }

        public void CreateTestMenu(List<Caffe> caffes)
        {
            using (var context = CreateLazyPhytonsContext())
            {
                var cafe = context.Caffes.FirstOrDefault(x => x.Name.Equals("Чемодан"));
                if (cafe == null)
                {
                    return;
                }

                context.Menus.Add(new Menu()
                {

                    Notes = "@Notes",
                    Caffe = cafe,
                    LinkToImage = "https://gurmans.dp.ua/chemodan/7201-large_default/salatsuposnovnoe-blyudo.jpg"
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
                    Notes = "С капустой белокачанной, сухариками, твердым сыром, под майонезно-чесночной заправкой",
                    Category = DishCategories.Salad,
                    Name = "Салат с охотничьими колбасками",
                    LinkToImage = "@Image",
                    Menu = menu,
                    MenuId = menu.Id
                });

                context.Dishes.Add(new Dish()
                {
                    Notes = "Огурцы и помидоры, болгарский перец, салатные листья, крымский лук",
                    Category = DishCategories.Salad,
                    Name = "Салат из свежих овощей",
                    LinkToImage = "",
                    Menu = menu,
                    MenuId = menu.Id
                });

                context.Dishes.Add(new Dish()
                {
                    Notes = "С корейской морковью, салатом \"Айсберг\", пекинской капустой и свежими томатами, с майонезно - сметанной заправкой с добавлением соуса \"Ткемали\"",
                    Category = DishCategories.Salad,
                    Name = "Пикантный салат с копченым цыпленком",
                    LinkToImage = "https://gurmans.dp.ua/chemodan/5858-home_default/salad-with-chicken.jpg",
                    Menu = menu,
                    MenuId = menu.Id
                });



                context.Dishes.Add(new Dish()
                {
                    Notes = "Нежный сливочный крем-суп из белых грибов с лучком и шампиньонами",
                    Category = DishCategories.Soup,
                    Name = "Крем-суп из белых грибов",
                    LinkToImage = "https://gurmans.dp.ua/chemodan/5868-large_default/syrnyj-sup.jpg",
                    Menu = menu,
                    MenuId = menu.Id
                });

                context.Dishes.Add(new Dish()
                {
                    Notes = "С филе домашнего цыпленка, яйцом, лапшой",
                    Category = DishCategories.Soup,
                    Name = "Домашний куриный бульон",
                    LinkToImage = "https://gurmans.dp.ua/chemodan/5870-large_default/chicken-bulion.jpg",
                    Menu = menu,
                    MenuId = menu.Id
                });

                context.Dishes.Add(new Dish()
                {
                    Notes = "С шампиньонами и вешенками",
                    Category = DishCategories.Soup,
                    Name = "Легкий сливочный суп с грибами",
                    LinkToImage = "https://gurmans.dp.ua/chemodan/5868-large_default/syrnyj-sup.jpg",
                    Menu = menu,
                    MenuId = menu.Id
                });


                context.Dishes.Add(new Dish()
                {
                    Notes = "Подается с картофелем по-селянски",
                    Category = DishCategories.Main,
                    Name = "Свинина под соусом \"Джек Дэниэлс\"",
                    LinkToImage = "@Image",
                    Menu = menu,
                    MenuId = menu.Id
                });

                context.Dishes.Add(new Dish()
                {
                    Notes = "Запеченный с помидорчиками и жареным лучком, сыром и майонезом,подается с картофельным пюре",
                    Category = DishCategories.Main,
                    Name = "Цыпленок под сырной шапкой	",
                    LinkToImage = "https://gurmans.dp.ua/chemodan/4651-large_default/chicken-with-cheese.jpg",
                    Menu = menu,
                    MenuId = menu.Id
                });

                context.Dishes.Add(new Dish()
                {
                    Notes = "Жареные во фритюре",
                    Category = DishCategories.Main,
                    Name = "2 чебурека с мясом",
                    LinkToImage = "@Image",
                    Menu = menu,
                    MenuId = menu.Id
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
