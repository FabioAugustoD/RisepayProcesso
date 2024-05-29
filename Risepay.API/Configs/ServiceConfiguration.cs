using Risepay.API.Services;
using Risepay.Infra.Interfaces;
using Risepay.Infra.Repositories;

namespace Risepay.API.Configs
{
    public class ServiceConfiguration
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            AddServices(serviceProvider);
        }

        private static void AddServices(IServiceCollection serviceProvider)
        {

            //serviceProvider.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAllOrigins",
            //        builder =>
            //        {
            //            builder.AllowAnyOrigin()
            //                   .AllowAnyMethod()
            //                   .AllowAnyHeader();
            //        });
            //});

            serviceProvider.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            serviceProvider.AddScoped<IColaboradorService, ColaboradorService>();
            serviceProvider.AddScoped<ICargoRepository, CargoRepository>();
            serviceProvider.AddScoped<ICargoService, CargoService>();
        }
    }
}
