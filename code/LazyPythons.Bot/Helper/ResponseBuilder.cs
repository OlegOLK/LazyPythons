using System;
using System.Collections.Generic;
using LazyPythons.Abstractions.Models;
using LPCommandExecutor.Response;

namespace LazyPythons.Helper
{
    public class ResponseBuilder
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

            return "Sorry, but something went wrong :(";
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
            string response = "###" + caffe.Name + "\n\n" 
                            + "##Description:\n\n" + caffe.Description + "\n\n"
                            + "##Price:\n\n" + caffe.Lunch2Price.ToString() + "for 2 dishes\n\n"
                            + caffe.Lunch3Price.ToString() + "for 3 dishes\n\n"
                            + "##Rating:\n\n" + caffe.Rating.ToString() + "\n\n"
                            + "\n\n" + caffe.LinkToImage + "\n\n"
                            + "##Distance from office:\n\n" + caffe.DistanceFromOffice.ToString() + "\n\n"
                            + "\n\n***\n\n***\n\n\n\n";

            return response;
        }
    }
}
