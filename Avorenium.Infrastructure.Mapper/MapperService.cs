using System;
using Avorenium.Core.Interfaces.Mapper;

namespace Avorenium.Infrastructure.Mapper
{
    public class MapperService : IMapperService
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(x => x.AddProfiles(new[] { "Avorenium.Infrastructure.Mapper" }));
        }

        public T Map<T>(object source) where T : class
        {
            if (source == null)
            {
                return default(T);
            }

            var destinationType = typeof(T);
            var sourceType = source.GetType();

            var result = AutoMapper.Mapper.Map(source, sourceType, destinationType);

            return result as T;
        }

        public T Map<T>(object source, object destination) where T : class
        {
            if (source == null || destination == null)
            {
                return default(T);
            }

            var destinationType = typeof(T);
            var sourceType = source.GetType();

            var result = AutoMapper.Mapper.Map(source, destination, sourceType, destinationType);

            return result as T;
        }
    }
}
