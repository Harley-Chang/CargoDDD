using AutoMapper;
namespace CargoDDD.WebApi.Mapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile<DtoToDoMappingProfile>();
                config.AddProfile<DoToDtoMappingProfile>();
            });
        }
    }
}
