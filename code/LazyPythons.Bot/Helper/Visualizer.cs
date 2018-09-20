using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LPCommandExecutor.Response;
using LPCommandExecutor.ViewModels;
using Microsoft.Bot.Builder;
using Microsoft.EntityFrameworkCore.Internal;

namespace LazyPythons.Helper
{
    public class Visualizer
    {
        private ITurnContext Context;

        public Visualizer(ITurnContext context)
        {
            this.Context = context;
        }

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

        public async Task RespondToExecution(IExecutorResponse response)
        {
            if (!response.IsSomethingFound)
            {
                await this.Context.SendActivity("Sorry, but nothing was found :(");
                return;
            }

            if (response.StringResponse != null)
            {
                await this.Context.SendActivity(response.StringResponse);
            }

            if (response.CafesResponse != null && EnumerableExtensions.Any(response.CafesResponse))
            {
                await this.RespondToCaffe(response.CafesResponse);
            }

            if (response.MenuViewModels != null && response.MenuViewModels.Any())
            {
                await this.RespondToMenu(response.MenuViewModels);
            }


           
        }

        public async Task RespondToMenu(IEnumerable<MenuViewModel> menus)
        {
            foreach (MenuViewModel elem in menus)
            {
                await this.RespondToMenu(elem);
            }
        }

        public async Task RespondToMenu(MenuViewModel menu)
        {
            string response = "# Menu in caffe " + menu.CaffeName + "\n\n" +
                              "![menu image](" + menu.LinkToImage + ")\n\n\n\n" +
                              "\n\n## Dishes: \n\n" +
                              FormatDishesResponse(menu.Dishes) + "\n\n" +
                              "## Beverages: \n\n" +
                              FormatBeveragesResponse(menu.Beverages) + "\n\n"
                              + "\n\n***\n\n***\n\n\n\n";

            await this.Context.SendActivity(response);
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
                    response += $"\n\n##{key}\n\n";
                    foreach (IDish dish in grouppedDish)
                    {
                        response += $"* ![{dish.Name}]({dish.LinkToImage})\n\n";

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
                    response += $"* ![{menuBeverages[i].Name}]({menuBeverages[i].LinkToImage})\n\n\n\n";
                }
            }
            return response;
        }

        public async Task RespondToCaffe(IEnumerable<ICaffe> cafes)
        {
            foreach (ICaffe elem in cafes)
            {
               await this.RespondToCaffe(elem);
            }
        }

        public async Task RespondToCaffe(ICaffe caffe)
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

            await this.Context.SendActivity(response);
        }
    }
}
