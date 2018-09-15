using AutoMapper;

namespace LazyPythons.Sql.Mappers
{
    public static class DishExtensions
    {
        public static LazyPythons.Models.Dish ToApi(this LazyPythons.Sql.Data.Dish obj)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<LazyPythons.Sql.Data.Dish, LazyPythons.Models.Dish>());
            return Mapper.Map<LazyPythons.Sql.Data.Dish, LazyPythons.Models.Dish>(obj);
        }

        public static LazyPythons.Sql.Data.Dish ToData(this LazyPythons.Models.Dish obj)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<LazyPythons.Models.Dish, LazyPythons.Sql.Data.Dish>());
            return Mapper.Map<LazyPythons.Models.Dish, LazyPythons.Sql.Data.Dish>(obj);
        }
    }
}
