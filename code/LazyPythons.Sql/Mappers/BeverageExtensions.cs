using AutoMapper;

namespace LazyPythons.Sql.Mappers
{
    public static class BeverageExtensions
    {

        public static LazyPythons.Models.Beverage ToApi(this LazyPythons.Sql.Data.Beverage obj)
        {
            return Mapper.Map<LazyPythons.Sql.Data.Beverage, LazyPythons.Models.Beverage>(obj);
        }

        public static LazyPythons.Sql.Data.Beverage ToData(this LazyPythons.Models.Beverage obj)
        {
            return Mapper.Map<LazyPythons.Models.Beverage, LazyPythons.Sql.Data.Beverage>(obj);
        }
    }
}
