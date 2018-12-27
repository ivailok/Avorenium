namespace Avorenium.Core.Interfaces.Mapper
{
    public interface IMapperService
    {
        TType Map<TType>(object source) where TType : class;

        TType Map<TType>(object source, object destination) where TType : class;
    }
}