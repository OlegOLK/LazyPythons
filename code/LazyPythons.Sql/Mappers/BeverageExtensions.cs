using AutoMapper;

namespace LazyPythons.Sql.Mappers
{
    public static class BeverageExtensions
    {
        public static LazyPythons.Models.Beverage ToApi(this LazyPythons.Sql.Data.Beverage obj)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<LazyPythons.Sql.Data.Beverage, LazyPythons.Models.Beverage>());
            return Mapper.Map<LazyPythons.Sql.Data.Beverage, LazyPythons.Models.Beverage>(obj);
        }

        public static LazyPythons.Sql.Data.Beverage ToData(this LazyPythons.Models.Beverage obj)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<LazyPythons.Models.Beverage, LazyPythons.Sql.Data.Beverage>());
            return Mapper.Map<LazyPythons.Models.Beverage, LazyPythons.Sql.Data.Beverage>(obj);
        }
    }
}
