using AutoMapper;

namespace LazyPythons.Sql.Mappers
{
    public static class DishExtensions
    {
        public static LazyPythons.Models.Dish ToApi(this LazyPythons.Sql.Data.Dish obj)
        {
            return Mapper.Map<LazyPythons.Sql.Data.Dish, LazyPythons.Models.Dish>(obj);
        }

        public static LazyPythons.Sql.Data.Dish ToData(this LazyPythons.Models.Dish obj)
        {
            return Mapper.Map<LazyPythons.Models.Dish, LazyPythons.Sql.Data.Dish>(obj);
        }
    }
}
