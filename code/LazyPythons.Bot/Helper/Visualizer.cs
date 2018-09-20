using System;
using System.Collections.Generic;
using System.Linq;
using LazyPythons.Abstractions.Models;
using LPCommandExecutor.Response;
using LPCommandExecutor.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;

namespace LazyPythons.Helper
{
    public class Visualizer
    {
        //string Name { get; }
        //string Description { get; }
        //long Latitude { get; }
        //long Longitude { get; }
        //short Rating { get; }
        //string LinkToImage { get; }
        //Guid MenuId { get; }
        //bool IsFreeBeverages { get; }
        //int Lunch2Price { get; }
        //int Lunch3Price { get; }
        //int DistanceFromOffice { get; }

        public string ExecutionToString(IExecutorResponse response)
        {
            if (response.StringResponse != null)
            {
                return response.StringResponse;
            }

            if (response.CafesResponse != null && EnumerableExtensions.Any(response.CafesResponse))
            {
                return this.CaffeToString(response.CafesResponse);
            }

            if (response.MenuViewModels != null && response.MenuViewModels.Any())
            {
                return this.MenuViewModelToString(response.MenuViewModels);
            }

            return "Sorry, but nothing was found :(";
        }

        public string MenuViewModelToString(IEnumerable<MenuViewModel> menus)
        {
            string response = "";
            foreach (MenuViewModel elem in menus)
            {
                response = response + this.MenuViewModelToString(elem);
            }

            return response;
        }

        public string MenuViewModelToString(MenuViewModel menu)
        {
            string response = "# Menu in caffe " + menu.CaffeName + "\n\n" +
                              "## ![alt text](" + menu.LinkToImage + " \"menu image\")\n\n" +
                              "## Dishes: \n\n" +
                              FormatDishesResponse(menu.Dishes) +
                              "## Beverages: \n\n" +
                              FormatBeveragesResponse(menu.Beverages)
                              + "\n\n***\n\n***\n\n\n\n";

            return response;
        }

        public string FormatDishesResponse(IEnumerable<IDish> dishes)
        {
            string response = "";
            if (dishes != null)
            {
                var grouppedDishes = dishes.GroupBy(x => x.Category);
                foreach (IGrouping<DishCategories, IDish> grouppedDish in grouppedDishes)
                {
                    var key = grouppedDish.Key;
                    response += $"* **{key}**\n";
                    foreach (IDish dish in grouppedDish)
                    {
                        response += $"\t* {dish.Name}\t ![dish {dish.Name} image]( {dish.LinkToImage})\n";

                    }
                }

            }
            return response;
        }

        public string FormatBeveragesResponse(IEnumerable<IBeverage> beverages)
        {
            string response = "";
            if (beverages != null)
            {
                var menuBeverages = beverages as IBeverage[] ?? beverages.ToArray();
                for (int i = 0; i < menuBeverages.Count(); i++)
                {
                    response += $"* {menuBeverages[i].Name}\t**Image:** {menuBeverages[i].LinkToImage}\n";
                }
            }
            return response;
        }

        public string CaffeToString(IEnumerable<ICaffe> cafes)
        {
            string response = "";
            foreach (ICaffe elem in cafes)
            {
                response = response + this.CaffeToString(elem);
            }

            return response;
        }

        public string CaffeToString(ICaffe caffe)
        {
            float time = caffe.DistanceFromOffice / 80;
            string response = "###" + caffe.Name + "\n\n"
                            + "##Description:\n\n" + caffe.Description + "\n\n"
                            + "##Price:\n\n" + caffe.Lunch2Price.ToString() + " hrn for 2 dishes\n\n"
                            + caffe.Lunch3Price.ToString() + " hrn for 3 dishes\n\n"
                            + "##Rating:\n\n" + caffe.Rating.ToString() + "\n\n"
                            + "\n\n" + caffe.LinkToImage + "\n\n"
                            + "##Distance from office:\n\n" + caffe.DistanceFromOffice.ToString() + " metters\n\n"
                            + "approximately " + time.ToString("0") + " minutes to go\n\n"
                            + "\n\n***\n\n***\n\n\n\n";

            return response;
        }
    }
}
