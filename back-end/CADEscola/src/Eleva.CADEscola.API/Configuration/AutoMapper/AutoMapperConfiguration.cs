using AutoMapper;
using Eleva.CADEscola.API.DTO;
using Eleva.CADEscola.Domain.Escolas;
using Eleva.CADEscola.Domain.Turmas;
using Microsoft.Extensions.DependencyInjection;

namespace Eleva.CADEscola.API.Configuration.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<EscolaDTO, Escola>().ReverseMap();
            CreateMap<TurmaDTO, Turma>().ReverseMap();
            CreateMap<CadastroEscolaDTO, Escola>().ReverseMap();
        }
    }

    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutoMapperConfiguration());
            });

            //mappingConfig.AssertConfigurationIsValid();
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
