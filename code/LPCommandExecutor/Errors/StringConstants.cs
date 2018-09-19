using System;
namespace LPCommandExecutor.Errors
{
    public static class StringConstants
    {
        public static string CAN_NOT_PARSE_REQUEST = "I can't understand you, please type /help";


        //regular expressions patterns
        public static string ChipperThanN = ".*lunch cheaper than (.*) hrn.*";
        public static string MenuInCaffeNamed = ".*menu in (.*)";
        public static string PriceInCaffeNamed = ".*lunch price in (.*)";
        public static string RatingForCaffeNamed = ".*menu in (.*)";
        public static string NMettersToGo = ".*lunch in (.*) meters to go.*";
        public static string NMinutesToGo = ".*lunch in (.*) minutes to go.*";
        public static string FreeBeverage = ".*with free beverage.*";
        public static string AllCafes = ".*all cafes.*"; //??????


        //обеды в<n> минутах хотьбы
        //обеды в окресности<n> метров
        //обеды не дороже<n> грн
        //обеды с бесплатными напитками
        //меню обеда в кафе <name>
        //цена обеда в кафе <name>
        //оценка обеда в кафе <name>
    }
}
