using AutoMapper;

namespace LazyPythons.Sql.Mappers
{
    public static class CaffeExtensions
    {
        public static LazyPythons.Models.Caffe ToApi(this LazyPythons.Sql.Data.Caffe obj)
        {
            Mapper.Initialize(cfg=> cfg.CreateMap<LazyPythons.Sql.Data.Caffe, LazyPythons.Models.Caffe>());
            return Mapper.Map<LazyPythons.Sql.Data.Caffe, LazyPythons.Models.Caffe>(obj);
        }

        public static LazyPythons.Sql.Data.Caffe ToData(this LazyPythons.Models.Caffe obj)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<LazyPythons.Models.Caffe, LazyPythons.Sql.Data.Caffe>());
            return Mapper.Map<LazyPythons.Models.Caffe, LazyPythons.Sql.Data.Caffe>(obj);
        }
    }
}
