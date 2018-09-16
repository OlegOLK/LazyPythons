using AutoMapper;

namespace LazyPythons.Sql.Mappers
{
    public static class MenuExtensions
    {
        public static LazyPythons.Models.Menu ToApi(this LazyPythons.Sql.Data.Menu obj)
        {
            return Mapper.Map<LazyPythons.Sql.Data.Menu, LazyPythons.Models.Menu>(obj);
        }

        public static LazyPythons.Sql.Data.Menu ToData(this LazyPythons.Models.Menu obj)
        {
            return Mapper.Map<LazyPythons.Models.Menu, LazyPythons.Sql.Data.Menu>(obj);
        }
    }
}
