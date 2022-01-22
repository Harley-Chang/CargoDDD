using AutoMapper;

namespace CargoDDD.Application.AutoMapper;
public class AutoMapperConfig
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(config =>
        {
            config.AddProfile<ModelToViewModelMappingProfile>();
            config.AddProfile<ViewModelToCommandMappingProfile>();
        });
    }
}
