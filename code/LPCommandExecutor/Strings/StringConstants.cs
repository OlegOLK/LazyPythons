using System;
namespace LPCommandExecutor
{
    public static class StringConstants
    {
        public static string CAN_NOT_PARSE_REQUEST = "I can't understand you, please type \"help\"";


        //regular expressions patterns
        public static string ChipperThanN = ".*lunch cheaper than (.*) hrn.*";
        public static string MenuInCaffeNamed = ".*menu in (.*)";
        public static string PriceInCaffeNamed = ".*lunch price in (.*)";
        public static string CafesWithRating = ".*cafes with rating (.*)";
        public static string NMettersToGo = ".*lunch in (.*) meters to go.*";
        public static string NMinutesToGo = ".*lunch in (.*) minutes to go.*";
        public static string FreeBeverage = ".*with free beverage.*";
        public static string AllCafes = ".*all cafes.*"; //??????
        public static string Help = "help";

        public static string AllFreedgePositions = ".*all propositions.*";
        public static string VoteForPosition = ".*vote for (.*)";
        public static string AddPosition = ".*add proposition for a fridge (.*)";



        public static string HelpResponse = "## Available commands:\n\n"
            + "* lunch cheaper than <sum> hrn\n\n"
            + "* menu in <caffe name>\n\n"
            + "* lunch price in <caffe name>\n\n"
            + "* cafes with rating <rating>\n\n"
            + "* lunch in <distance> meters to go\n\n"
            + "* lunch in <count> minutes to go\n\n"
            + "* with free beverage\n\n"
            + "* all cafes\n\n";
    }
}
