using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LPCommandExecutor.Response;
using LPCommandExecutor.ViewModels;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
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

        private IMessageActivity CreateReplyWith(string text, string imageLink, string imageName)
        {
            Attachment attachment = new Attachment();
            attachment.ContentType = "image/jpg";
            attachment.ContentUrl = imageLink;
            attachment.Name = imageName;

            IMessageActivity reply;

            if (text == null){
                reply = this.Context.Activity.CreateReply();
            } else {
                reply = this.Context.Activity.CreateReply(text);
            }

            reply.Attachments.Add(attachment);

            return reply;
        }

        public async Task RespondToMenu(IEnumerable<MenuViewModel> menus)
        {
            bool showDetailedMenu = (menus.Count() == 1);
            foreach (MenuViewModel elem in menus)
            {
                await this.RespondToMenu(elem, showDetailedMenu);
            }
        }

        public async Task RespondToMenu(MenuViewModel menu, bool showDetailedMenu)
        {
            string response = "# Menu in caffe " + menu.CaffeName + "\n\n";

            IMessageActivity reply = this.CreateReplyWith(response, menu.LinkToImage, "current menu");

            await this.Context.SendActivity(reply);

            if (showDetailedMenu)
            { 
                await this.Context.SendActivity("\n\n## Dishes:\n\n\n\n");

                await this.FormatDishesResponse(menu.Dishes);

                await this.Context.SendActivity("\n\n## Beverages:\n\n\n\n");

                await this.FormatBeveragesResponse(menu.Beverages);
            }
        }

        public async Task FormatDishesResponse(IEnumerable<IDish> dishes)
        {
            if (dishes != null)
            {
                var grouppedDishes = dishes.GroupBy(x => x.Category);
                foreach (IGrouping<DishCategories, IDish> grouppedDish in grouppedDishes)
                {
                    var key = grouppedDish.Key;
                    await this.Context.SendActivity($"\n\n##{key}\n\n");

                    foreach (IDish dish in grouppedDish)
                    {
                        IMessageActivity reply = this.CreateReplyWith(null , dish.LinkToImage, dish.Name);

                        await this.Context.SendActivity(reply);
                    }
                }
            }
        }

        public async Task FormatBeveragesResponse(IEnumerable<IBeverage> beverages)
        {
            if (beverages != null)
            {
                var menuBeverages = beverages as IBeverage[] ?? beverages.ToArray();
                for (int i = 0; i < menuBeverages.Count(); i++)
                {
                    IMessageActivity reply = this.CreateReplyWith(null, menuBeverages[i].LinkToImage, menuBeverages[i].Name);

                    await this.Context.SendActivity(reply);
                }
            }
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
