using Eleva.CADEscola.Domain.Escolas.Interfaces;
using Eleva.CADEscola.Domain.Escolas.Services;
using Eleva.CADEscola.Domain.Turmas.Interfaces;
using Eleva.CADEscola.Domain.Turmas.Services;
using Eleva.CADEscola.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Eleva.CADEscola.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra Data
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();

            // Domain Service
            services.AddScoped<IEscolaService, EscolaService>();
            services.AddScoped<ITurmaService, TurmaService>();
        }
    }
}
