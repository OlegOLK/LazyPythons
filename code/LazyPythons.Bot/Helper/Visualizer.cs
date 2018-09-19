using System;
using System.Collections.Generic;
using LazyPythons.Abstractions.Models;
using LPCommandExecutor.Response;

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

            if (response.CafesResponse != null)
            {
                return this.CaffeToString(response.CafesResponse);
            }

            return "Sorry, but nothing was found :(";
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
